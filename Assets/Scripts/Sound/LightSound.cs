using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSound : MonoBehaviour
{
    private bool isSoundPlaying = false;
    private StudioEventEmitter lightChargeEmitter;
    private Dictionary<EventReference, bool> soundInstances = new Dictionary<EventReference, bool>();

    private LightBehaviour LightBehaviour;

    private float knobValue;
    private bool lightIsSet;
    private float blinkInterval;
    private bool coroutineStarted;
    private float LightDuration;
    private float preDelay;
    private bool hasPlayedBlinkSound = false;

    private bool isOn;

    // Start is called before the first frame update
    private void Start()
    {
        LightBehaviour = FindObjectOfType<LightBehaviour>();
        lightChargeEmitter = gameObject.AddComponent<StudioEventEmitter>();
        lightChargeEmitter = AudioManager.instance.InitializeEventEmitter(FMODEvents.instance.LightCharge, gameObject);
        lightChargeEmitter.PlayEvent = EmitterGameEvent.None;
        lightChargeEmitter.StopEvent = EmitterGameEvent.None;

        lightChargeEmitter.Play(); // Start playing the emitter but keep it paused initially
        lightChargeEmitter.EventInstance.setPaused(true);
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
                lightChargeEmitter.EventInstance.setPaused(false);
            }
            else if (knobValue == 0)
            {
                AudioManager.instance.SetEmitterParameter(lightChargeEmitter, "LightChargeLoop", 0);
                AudioManager.instance.SetEmitterParameter(lightChargeEmitter, "LightLoop", 0);
                lightChargeEmitter.EventInstance.setPaused(true);
            }
        }
        else
        {
            AudioManager.instance.SetEmitterParameter(lightChargeEmitter, "LightChargeLoop", 0);
            AudioManager.instance.SetEmitterParameter(lightChargeEmitter, "LightLoop", 0);
            lightChargeEmitter.EventInstance.setPaused(true);
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

    private void BlinkingBehaviour()
    {
        isOn = LightBehaviour.GetOnState();
        if (blinkInterval < 0.1f)
        {
            AudioManager.instance.SetEmitterParameter(lightChargeEmitter, "LightLoop", 0);
            AudioManager.instance.SetEmitterParameter(lightChargeEmitter, "LightChargeLoop", 1);
        }
        else if (blinkInterval >= 0.1f)
        {
            AudioManager.instance.SetEmitterParameter(lightChargeEmitter, "LightChargeLoop", 0);
            AudioManager.instance.SetEmitterParameter(lightChargeEmitter, "LightLoop", 1);
        }

        isSoundPlaying = blinkInterval < 1;
        bool shouldPlayBlinkSound = !isOn && isSoundPlaying && !hasPlayedBlinkSound;

        if (shouldPlayBlinkSound)
        {
            AudioManager.instance.PlayOneShot(FMODEvents.instance.Blink, transform.position);
            hasPlayedBlinkSound = true;
        }
        else if (isOn || blinkInterval >= 1)
        {
            hasPlayedBlinkSound = false;
        }
    }
}
