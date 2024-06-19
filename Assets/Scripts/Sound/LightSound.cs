using FMOD.Studio;
using FMODUnity;
using System;
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
        previousKnobValue = LightBehaviour.GetKnobValue();
        lightChargeInstance = AudioManager.instance.CreateInstance(FMODEvents.instance.LightCharge);
        Blink = AudioManager.instance.CreateInstance(FMODEvents.instance.Blink);
        lightChargeInstance.start(); lightChargeInstance.release(); lightChargeInstance.setPaused(true);
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
        

        float currentTime = Time.time;

        if (!lightIsSet)
        {  
            if (knobValue > 0 && knobValue < 1)
            {
                BlinkingBehaviour();
                lightChargeInstance.setPaused(false);

            }
            else if (knobValue == 0) {
                AudioManager.instance.SetInstanceParameter(lightChargeInstance, "LightChargeLoop", 0);
                AudioManager.instance.SetInstanceParameter(lightChargeInstance, "LightLoop", 0);
                lightChargeInstance.setPaused(true);
            }
        }
        else
        {
            AudioManager.instance.SetInstanceParameter(lightChargeInstance, "LightChargeLoop", 0);
            AudioManager.instance.SetInstanceParameter(lightChargeInstance, "LightLoop", 0);
            lightChargeInstance.setPaused(true);
            if (!coroutineStarted)
            {
                AudioManager.instance.PlayOneShot(FMODEvents.instance.LightOn, transform.position);
                AudioManager.instance.PlayOneShot(FMODEvents.instance.WheelFull, transform.position);
                StartCoroutine(LightingCoroutine());
            }
        }
    }


    IEnumerator LightingCoroutine()
    {
        yield return new WaitForSeconds(LightDuration);
        AudioManager.instance.PlayOneShot(FMODEvents.instance.LightWarning, transform.position);

        yield return new WaitForSeconds(preDelay);
        StartCoroutine(EndBlinkCoroutine());
    }

    IEnumerator EndBlinkCoroutine()
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
    private bool isChargePlaying;

    private void BlinkingBehaviour()
    {
        
        isOn = LightBehaviour.GetOnState();
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
        isSoundPlaying = blinkInterval < 1;
        // Determine if the blink sound should be played
        bool shouldPlayBlinkSound = !isOn && isSoundPlaying && !hasPlayedBlinkSound;

        if (shouldPlayBlinkSound)
        {
            // Start playing the blink sound
            AudioManager.instance.PlayOneShot(FMODEvents.instance.Blink, transform.position);
            //Debug.Log("Blink");

            hasPlayedBlinkSound = true; // Mark that the blink sound has been played
        }
        else if (isOn || blinkInterval >= 1)
        {
            // Reset the flag when the light is on or the blink interval is >= 1
            hasPlayedBlinkSound = false;
        }   
    }
}