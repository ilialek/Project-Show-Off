using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Tayx.Graphy.Audio;
using UnityEngine;

public class LightSound : MonoBehaviour
{
    private bool isSoundPlaying = false;
    private EventInstance lightChargeInstance;
    private EventInstance Blink;
    private Dictionary<EventReference, bool> soundInstances = new Dictionary<EventReference, bool>();

    private LightBehaviour LightBehaviour;

    private float knobValue;
    private float previousKnobValue;
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
        lightChargeInstance = AudioManager.instance.CreateInstance(FMODEvents.instance.LightCharge);
        Blink = AudioManager.instance.CreateInstance(FMODEvents.instance.Blink);
        previousKnobValue = LightBehaviour.GetKnobValue();
    }

    public void PlayOneShotSound(EventReference sound, Vector3 worldPos)
    {
        if (!soundInstances.ContainsKey(sound) || !soundInstances[sound])
        {
            soundInstances[sound] = true;
            AudioManager.instance.PlayOneShot(sound, worldPos);
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
        knobValue = LightBehaviour.GetKnobValue();
        lightIsSet = LightBehaviour.GetLightState();
        blinkInterval = LightBehaviour.GetBlinkInterval();
        coroutineStarted = LightBehaviour.GetCoroutineState();
        LightDuration = LightBehaviour.GetLightDuration();
        preDelay = LightBehaviour.GetPreDelay();
        isOn = LightBehaviour.GetOnState();

        float currentTime = Time.time;

        if (!lightIsSet)
        {
            if (knobValue > 0 && knobValue < 1)
            {
                BlinkingBehaviour();
            }
            else if (knobValue == 1)
            {
                lightChargeInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                Debug.Log("Light On/Wheel full");
            }
        }
        else
        {
            if (!coroutineStarted)
            {
                //PlayOneShotSound(FMODEvents.instance.LightOn, transform.position);
                //PlayOneShotSound(FMODEvents.instance.WheelFull, transform.position);
                AudioManager.instance.PlayOneShot(FMODEvents.instance.LightOn, transform.position);
                AudioManager.instance.PlayOneShot(FMODEvents.instance.WheelFull, transform.position);
                lightChargeInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                StartCoroutine(LightingCoroutine());
            }
        }
        /*
        bool wasSoundPlaying = isSoundPlaying;
        isSoundPlaying = blinkInterval < 1;
        //Debug.Log($"Blink Interval: {blinkInterval}, IsSoundPlaying: {isSoundPlaying}");

        //Debug.Log(isOn);

        bool shouldPlayBlinkSound = !isOn && !hasPlayedBlinkSound && isSoundPlaying;

        if (shouldPlayBlinkSound)
        {
            // Start playing the blink sound
            Blink.start();
            //AudioManager.instance.PlayOneShot(FMODEvents.instance.Blink, transform.position);
            hasPlayedBlinkSound = true; // Mark that the blink sound has been played
            isSoundPlaying = false;
            Debug.Log("Blink");
        }

        if (!isSoundPlaying && wasSoundPlaying)
        {
            // Stop playing the light charge sound
            //Blink.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            lightChargeInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            PlayOneShotSound(FMODEvents.instance.LightOffclick, transform.position);
            hasPlayedBlinkSound = false; // Reset flag when blink stops
            Debug.Log("No Blink");
        }
        */
    }


    IEnumerator LightingCoroutine()
    {
        yield return new WaitForSeconds(LightDuration);
        PlayOneShotSound(FMODEvents.instance.LightWarning, transform.position);

        yield return new WaitForSeconds(preDelay);
        StartCoroutine(EndBlinkCoroutine());
    }

    IEnumerator EndBlinkCoroutine()
    {
        float totalTime = 0f;
        float blinkInterval = 0.05f; // Interval between blinks in seconds
        float blinkDuration = 1.6f; // Total duration of blinking in seconds

        // Play the one-shot sound before starting the blinking
        //PlayOneShotSound(FMODEvents.instance.LightOff, transform.position);
        AudioManager.instance.PlayOneShot(FMODEvents.instance.LightOff, transform.position);

        while (totalTime < blinkDuration)
        {
            yield return new WaitForSeconds(blinkInterval);
            totalTime += blinkInterval;
        }
    }

    private void BlinkingBehaviour()
    {


        bool wasSoundPlaying = isSoundPlaying;

        // Determine if a new blink sound should play
        bool shouldPlayBlinkSound = isOn && isSoundPlaying;
        AudioManager.instance.SetInstanceParameter(Blink, "BlinkCharge", blinkInterval);
        if (shouldPlayBlinkSound)
        {
            // Start playing the blink sound
            Blink.start();
            hasPlayedBlinkSound = true; // Mark that the blink sound has been played
            isSoundPlaying = false;
            //Debug.Log("Blink");
        }
        hasPlayedBlinkSound = false; // Reset flag when blink stops
        isSoundPlaying = true;

        isSoundPlaying = blinkInterval < 1;
        //Debug.Log($"Blink Interval: {blinkInterval}, IsSoundPlaying: {isSoundPlaying}");

        //Debug.Log(isOn);

        if (blinkInterval < 0.1f)
        {
            //Debug.Log("FastBlink");
            AudioManager.instance.SetInstanceParameter(lightChargeInstance, "LightLoop", 0);
            AudioManager.instance.SetInstanceParameter(lightChargeInstance, "LightChargeLoop", 1);
        }
        else if (blinkInterval >= 0.1f)
        {
            //Debug.Log("SlowBlink");
            AudioManager.instance.SetInstanceParameter(lightChargeInstance, "LightChargeLoop", 0);
            AudioManager.instance.SetInstanceParameter(lightChargeInstance, "LightLoop", 1);
        }

        if (isSoundPlaying && !wasSoundPlaying)
        {
            // Start playing the light charge sound
            lightChargeInstance.start();
            AudioManager.instance.SetInstanceParameter(lightChargeInstance, "LightLoop", 0);
            AudioManager.instance.SetInstanceParameter(lightChargeInstance, "LightChargeLoop", 1);
            
            Debug.Log("Light charge started");
        }
        else if (!isSoundPlaying && wasSoundPlaying)
        {
            Blink.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            lightChargeInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            AudioManager.instance.PlayOneShot(FMODEvents.instance.LightOffclick, transform.position);
            Debug.Log("Light charge stopped");
        }
     
    }
}