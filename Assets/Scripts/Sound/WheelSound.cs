using FMOD.Studio;
using FMODUnity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XRKnob = UnityEngine.XR.Content.Interaction.XRKnob;


public class WheelSound : MonoBehaviour
{
    private EventInstance wheelChargeInstance;
    private EventInstance backspinInstance;

    private bool isWheelChargePlaying = false;
    private bool isBackspinPlaying = false;

    private bool isUserInteracting = false;

    private float rotation;
    private float previousRotation;

    [SerializeField]
    private float RotationTreshold = 0.1f; 

    private bool isRotationChanging = false;
    private bool hasPlayedWheelNull = true;



    // Previous value and time
    private float previousValue;
    private float previousTime;

    // Current rate of change
    public float rateOfChange;
    private float smoothedRateOfChange;

    private XRKnob XRKnob;
    void Start()
    {
        backspinInstance = AudioManager.instance.CreateInstance(FMODEvents.instance.Backspin);
        wheelChargeInstance = AudioManager.instance.CreateInstance(FMODEvents.instance.WheelRotation);

        XRKnob = FindObjectOfType<XRKnob>();

        wheelChargeInstance.start(); wheelChargeInstance.release(); wheelChargeInstance.setPaused(true);
        backspinInstance.start(); backspinInstance.release(); backspinInstance.setPaused(true);

        previousValue = Mathf.Clamp(XRKnob.GetTheYRotationInDegrees(), 0f, 1f);
        previousTime = Time.time;

    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rotation = XRKnob.GetTheYRotationInDegrees();
        float normalizedRotation = NormalizeRotation(rotation);

        HandleSoundLogic();

        // Clamp rotation for rate of change calculation
        float rotationspeed = Mathf.Clamp(normalizedRotation, 0f, 1f);

        // Calculate the current time and value
        float currentTime = Time.time;
        float currentValue = rotationspeed;

        // Calculate the change in value and time
        float deltaValue = currentValue - previousValue;
        float deltaTime = currentTime - previousTime;

        // Calculate the rate of change (deltaValue / deltaTime)
        if (deltaTime > 0) // Ensure we don't divide by zero
        {
            rateOfChange = deltaValue / deltaTime;
        }

        // Smooth the rate of change using a simple moving average
        smoothedRateOfChange = Mathf.Lerp(smoothedRateOfChange, rateOfChange, 0.1f);

        smoothedRateOfChange = Mathf.Clamp(smoothedRateOfChange, 0f, 1f);

        // Update previous values for the next frame
        previousValue = currentValue;
        previousTime = currentTime;

        // Debug log the rate of change
        Debug.Log(smoothedRateOfChange);

        AudioManager.instance.SetInstanceParameter(wheelChargeInstance,"WheelForce", smoothedRateOfChange);
    }

    // Normalize rotation value to be between 0 and 1
    private float NormalizeRotation(float rotation)
    {
        // Assuming rotation is in degrees and ranges between 0 and 360
        return Mathf.InverseLerp(0f, 360f, rotation);
    }



    // Method to play the wheel charge sound
    private void PlayWheelChargeSound()
    {
        if (!isWheelChargePlaying && wheelChargeInstance.isValid())
        {
            wheelChargeInstance.setPaused(false);
            isWheelChargePlaying = true;
        }
    }

    // Method to play the backspin sound
    private void PlayBackspinSound()
    {
        if (!isBackspinPlaying && backspinInstance.isValid())
        {
            backspinInstance.setPaused(false);
            isBackspinPlaying = true;
        }
    }

    // Method to stop and release the wheel charge sound
    private void StopAndReleaseWheelChargeSound()
    {
        if (isWheelChargePlaying && wheelChargeInstance.isValid())
        {
            wheelChargeInstance.setPaused(true);
            isWheelChargePlaying = false;
        }
    }

    // Method to stop and release the backspin sound
    private void StopAndReleaseBackspinSound()
    {
        if (isBackspinPlaying && backspinInstance.isValid())
        {
            backspinInstance.setPaused(true);
            isBackspinPlaying = false;
        }
    }

    // Revised sound logic to handle sound instances without overlap
    private void HandleSoundLogic()
    {
        isUserInteracting = XRKnob.GetUserState();


        isRotationChanging = Mathf.Abs(rotation - previousRotation) > RotationTreshold;
        //Debug.Log($"Radical Change! Current: {rotation}, Previous: {previousRotation}, Difference: {Math.Abs(rotation - previousRotation)}");

        // Check rotation angle and user interaction to determine which sound to play
        if (isUserInteracting && rotation > 0.1f && isRotationChanging)
        {           
            PlayWheelChargeSound();
            StopAndReleaseBackspinSound();
            hasPlayedWheelNull = false;
        }
        else if (rotation > 0.1f && isRotationChanging)
        {
            PlayBackspinSound();
            StopAndReleaseWheelChargeSound();
            hasPlayedWheelNull = false;
        }
        else if (rotation <= 0.1f && !isUserInteracting && !hasPlayedWheelNull)
        {
            AudioManager.instance.PlayOneShot(FMODEvents.instance.WheelNull, transform.position);
            StopAndReleaseWheelChargeSound();
            StopAndReleaseBackspinSound();
            hasPlayedWheelNull = true;
            Debug.Log("Wheel null sound played");
        }
        else
        {
            StopAndReleaseWheelChargeSound();
            StopAndReleaseBackspinSound();
        }

        previousRotation = rotation; // Update previousRotation for next frame
    }


}
