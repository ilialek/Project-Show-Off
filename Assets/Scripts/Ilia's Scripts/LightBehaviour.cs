using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Experimental.GlobalIllumination;
using FMODUnity;
using FMOD.Studio;

public class LightBehaviour : MonoBehaviour
{
    [SerializeField] private float lightingDuration;
    [SerializeField] private LayerMask detectableLayer;

    private bool lightIsSet = false;
    private bool coroutineStarted = false;

    private Light lightComponent;

    private float blinkInterval = 1.0f; // Interval between blinks in seconds
    private bool isOn = true; // Track if the light is on or off
    private float timer = 0f;

    private float knobValue = 0;

    public TextMeshPro textMeshPro;

    private AudioManager audioManager;
    private bool isSoundPlaying = false;
    private EventInstance lightChargeInstance;

    void Start()
    {
        lightComponent = GetComponent<Light>();
        lightComponent.enabled = false;

        audioManager = AudioManager.instance;

        if (audioManager == null)
        {
            Debug.LogError("AudioManager instance is not found in the scene.");
        }
    }
    private Dictionary<EventReference, bool> soundInstances = new Dictionary<EventReference, bool>();

    public void PlayOneShotSound(EventReference sound, Vector3 worldPos)
    {
        if (!soundInstances.ContainsKey(sound) || !soundInstances[sound])
        {
            soundInstances[sound] = true;
            audioManager.PlayOneShot(sound, worldPos);
            StartCoroutine(ResetSoundState(sound));
        }
    }

    private IEnumerator ResetSoundState(EventReference sound)
    {
        yield return new WaitForSeconds(2f);
        soundInstances[sound] = false;
    }
    // Update is called once per frame
    void Update()
    {
        textMeshPro.text = "Not";
        DetectObjects();

        

        if (!lightIsSet)
        {
            if (knobValue > 0 && knobValue < 1)
            {
                
                BlinkingBehaviour();
            }
            else if (knobValue == 1)
            {
                //Debug.Log("worked");
                PlayOneShotSound(FMODEvents.instance.LightOn, transform.position);
                PlayOneShotSound(FMODEvents.instance.WheelFull, transform.position);
                lightComponent.enabled = true;
                lightIsSet = true;
            }
            else if (knobValue == 0)
            {
                lightComponent.enabled = false;
            }
        }
        else
        {
            if (!coroutineStarted)
            {
                StartCoroutine(LightingCoroutine());
                
                coroutineStarted = true;
            }
        }



    }

    IEnumerator LightingCoroutine()
    {
        float preSoundDelay = 1.5f; // Delay before playing the one-shot sound   

        yield return new WaitForSeconds(lightingDuration);
        PlayOneShotSound(FMODEvents.instance.LightWarning, transform.position);
        yield return new WaitForSeconds(preSoundDelay);

        StartCoroutine(EndBlinkCoroutine());
    }

    IEnumerator EndBlinkCoroutine()
    {
        float totalTime = 0f;
        float blinkInterval = 0.05f; // Interval between blinks in seconds
        float blinkDuration = 1.6f; // Total duration of blinking in seconds



        PlayOneShotSound(FMODEvents.instance.LightOff, transform.position);
        // Play the one-shot sound before starting the blinking

        while (totalTime < blinkDuration)
        {
            
            lightComponent.enabled = !lightComponent.enabled;

            yield return new WaitForSeconds(blinkInterval);

            totalTime += blinkInterval;
        }
        
        // Ensure the light is on after the blinking is finished
        lightComponent.enabled = false;
        

        lightIsSet = false;
        coroutineStarted = false;
    }

 
    private void BlinkingBehaviour()
    {
        if (knobValue > 0)
        {
            blinkInterval = 1 / (knobValue * 17);
            //Debug.Log(blinkInterval.ToString());
        }
        bool wasSoundPlaying = isSoundPlaying;
        isSoundPlaying = blinkInterval <1 && knobValue < 1;

        if (isSoundPlaying && !wasSoundPlaying)
        {
            // Start playing the light charge sound
            lightChargeInstance = RuntimeManager.CreateInstance(FMODEvents.instance.LightCharge);
            lightChargeInstance.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));
            lightChargeInstance.start();
        }
        else if (!isSoundPlaying && wasSoundPlaying)
        {
            // Stop playing the light charge sound
            lightChargeInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            lightChargeInstance.release();
        }
        timer += Time.deltaTime; // Increment the timer

        if (timer >= blinkInterval)
        {
            isOn = !isOn; // Toggle the light on/off
            lightComponent.enabled = isOn; // Set the light's enabled state
            timer = 0f; // Reset the timer
        }

        
    }

    void DetectObjects()
    {
        // Get all colliders within the spotlight's range
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, lightComponent.range, detectableLayer);

        foreach (Collider hitCollider in hitColliders)
        {
            Vector3 directionToTarget = hitCollider.transform.position - transform.position;
            float angleToTarget = Vector3.Angle(transform.forward, directionToTarget);

            if (angleToTarget < lightComponent.spotAngle / 2)
            {
                // Object is within the spotlight's cone

                textMeshPro.text = "Detected";
                Debug.Log("Detected object: " + hitCollider.name);
                // Add your custom logic here (e.g., triggering events, applying effects, etc.)
            }
            
        }
    }

    public void IsLightSet(bool _value)
    {
        lightIsSet = _value;
    }
    public void ReceiveTheRotationValue(float _value)
    {
        knobValue = _value;
    }
}
