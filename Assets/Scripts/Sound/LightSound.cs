using FMOD.Studio;
using FMODUnity;
using System.Collections;
using UnityEngine;

public class LightSound : MonoBehaviour
{
    private bool isSoundPlaying = false;
    private EventInstance lightChargeInstance;

    private LightBehaviour LightBehaviour;

    private float knobValue;
    private bool lightIsSet;
    private float blinkInterval;
    private bool coroutineStarted;
    private float LightDuration;
    private float preDelay;
    private bool hasPlayedBlinkSound = false;

    private bool isOn;

    private GameObject Generator;

    // Start is called before the first frame update
    private void Start()
    {
        LightBehaviour = FindObjectOfType<LightBehaviour>();

        // Create the instance of the sound event
        lightChargeInstance = AudioManager.instance.CreateInstance(FMODEvents.instance.LightCharge);
        lightChargeInstance.start(); lightChargeInstance.release();
        lightChargeInstance.setPaused(true); // Initially paused
        Generator = GameObject.Find("Generator");
        lightChargeInstance.set3DAttributes(RuntimeUtils.To3DAttributes(transform, Generator.GetComponent<Rigidbody>()));

    }

    // Update is called once per frame
    private void Update()
    {
        knobValue = LightBehaviour.GetKnobValue();
        lightIsSet = LightBehaviour.GetLightState();
        blinkInterval = LightBehaviour.GetBlinkInterval();
        coroutineStarted = LightBehaviour.GetCoroutineState();
        LightDuration = LightBehaviour.GetLightDuration();
        preDelay = LightBehaviour.GetPreDelay();

        if (!lightIsSet)
        {
            if (knobValue > 0 && knobValue < 1)
            {
                BlinkingBehaviour();
                lightChargeInstance.setPaused(false);
            }
            else if (knobValue == 0)
            {
                lightChargeInstance.setPaused(true);
            }
        }
        else
        {
            lightChargeInstance.setPaused(true);

            if (!coroutineStarted)
            {
                AudioManager.instance.PlayOneShot(FMODEvents.instance.LightOn, transform.position);
                AudioManager.instance.PlayOneShot(FMODEvents.instance.WheelFull, transform.position);
                StartCoroutine(LightingCoroutine());
            }
        }
    }

    private IEnumerator LightingCoroutine()
    {
        yield return new WaitForSeconds(LightDuration);
        AudioManager.instance.PlayOneShot(FMODEvents.instance.LightWarning, transform.position);

        yield return new WaitForSeconds(preDelay);
        StartCoroutine(EndBlinkCoroutine());
    }

    private IEnumerator EndBlinkCoroutine()
    {
        float totalTime = 0f;
        float blinkInterval = 0.05f; // Interval between blinks in seconds
        float blinkDuration = 1.6f; // Total duration of blinking in seconds

        AudioManager.instance.PlayOneShot(FMODEvents.instance.LightOff, transform.position);

        while (totalTime < blinkDuration)
        {
            yield return new WaitForSeconds(blinkInterval);
            totalTime += blinkInterval;
        }
    }
    [SerializeField, Range(0.1f, 10f)] private float blinktresh;
    private void BlinkingBehaviour()
    {
        if (Generator != null)
        {
            Rigidbody generatorRigidbody = Generator.GetComponent<Rigidbody>();
            if (generatorRigidbody != null)
            {
                lightChargeInstance.set3DAttributes(RuntimeUtils.To3DAttributes(Generator.transform, generatorRigidbody));
            }
            else
            {
                lightChargeInstance.set3DAttributes(RuntimeUtils.To3DAttributes(Generator.transform));
            }
        }

        isOn = LightBehaviour.GetOnState();

        if (blinkInterval < 0.2f)
        {
            AudioManager.instance.SetInstanceParameter(lightChargeInstance, "Lightloop", 0f);
            AudioManager.instance.SetInstanceParameter(lightChargeInstance, "LightChargeLoop", 1f);
            //Debug.Log("fastblink");
        }
        else if (blinkInterval >= 0.2f)
        {
            AudioManager.instance.SetInstanceParameter(lightChargeInstance, "LightChargeLoop", 0f);
            AudioManager.instance.SetInstanceParameter(lightChargeInstance, "Lightloop", 1f);
            //Debug.Log("slowblink");
        } else if (blinkInterval >= 0.8f)
        {
            AudioManager.instance.SetInstanceParameter(lightChargeInstance, "LightChargeLoop", 0f);
            AudioManager.instance.SetInstanceParameter(lightChargeInstance, "Lightloop", 0f);
            //Debug.Log("blinkfadeout");
        }

        isSoundPlaying = blinkInterval < 1;
        bool shouldPlayBlinkSound = !isOn && isSoundPlaying && !hasPlayedBlinkSound;

        if (shouldPlayBlinkSound)
        {

            float blinkSound = blinkInterval * blinktresh;
            blinkSound = Mathf.Clamp01(blinkSound);
            //Debug.Log($"Playing Blink sound with BlinkIntensity: {blinkSound}");
            // Use the custom utility method to play the Blink sound with parameters
            AudioManager.PlayOneShotWithParameters(FMODEvents.instance.Blink, Generator.transform.position, ("BlinkCharge", blinkSound));
            hasPlayedBlinkSound = true;
        }
        else if (isOn || blinkInterval >= 1)
        {
            hasPlayedBlinkSound = false;
        }
    }
}
