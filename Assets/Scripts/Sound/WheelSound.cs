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

    private XRKnob XRKnob;
    void Start()
    {
        backspinInstance = AudioManager.instance.CreateInstance(FMODEvents.instance.Backspin);
        wheelChargeInstance = AudioManager.instance.CreateInstance(FMODEvents.instance.WheelRotation);

        XRKnob = FindObjectOfType<XRKnob>();
    }

    private void FixedUpdate()
    {      
        HandleSoundLogic();
    }

    // Method to play the wheel charge sound
    private void PlayWheelChargeSound()
    {
        if (!isWheelChargePlaying && wheelChargeInstance.isValid())
        {
            wheelChargeInstance.start();
            isWheelChargePlaying = true;
        }
    }

    // Method to play the backspin sound
    private void PlayBackspinSound()
    {
        if (!isBackspinPlaying && backspinInstance.isValid())
        {
            backspinInstance.start();
            isBackspinPlaying = true;
        }
    }

    // Method to stop and release the wheel charge sound
    private void StopAndReleaseWheelChargeSound()
    {
        if (isWheelChargePlaying && wheelChargeInstance.isValid())
        {
            wheelChargeInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            isWheelChargePlaying = false;
        }
    }

    // Method to stop and release the backspin sound
    private void StopAndReleaseBackspinSound()
    {
        if (isBackspinPlaying && backspinInstance.isValid())
        {
            backspinInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            isBackspinPlaying = false;
        }
    }

    // Revised sound logic to handle sound instances without overlap
    private void HandleSoundLogic()
    {
        isUserInteracting = XRKnob.GetUserState();
        rotation = XRKnob.GetTheYRotationInDegrees();

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
