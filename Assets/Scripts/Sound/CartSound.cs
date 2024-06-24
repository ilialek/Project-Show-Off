using FMOD.Studio;
using FMODUnity;
using System;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class CartSound : MonoBehaviour
{
    private float speed;
    private float smoothedSpeed;
    private float rattle;

    [SerializeField, Range(0.01f, 1f)] private float smoothSpeedFactor = 0.1f;

    [SerializeField] private EngineTemperature engineheat;

    private PlayerProgression playerProgression;
    private XRLever xrLever;
    //private EngineTemperature engineTemperature;
    private StudioEventEmitter cartEmitter;

    private EventInstance leverInstance;
    private EventInstance engineHeatInstance;
    private float rotationStrength;
    private bool isPlaying;
    private bool brakeOn = false;

    private float initialLeverValue;
    private float previousValue;
    private bool hasSignificantChange;
    private bool isAtDefaultPosition = true;
    bool isUserInteracting;
    private bool hasEndPlayed;

    private float leverPosition;

    [SerializeField, Range(0.001f, 1f)] private float threshold = 0.001f;
    [SerializeField, Range(0.01f, 0.1f)] private float deadzone = 0.01f;

    void Start()
    {
        Debug.Log("Start called");
        InitializeComponents();
        InitializeAudioInstances();
    }

    private void FixedUpdate()
    {
        UpdateSoundLogic();
    }

    private void InitializeComponents()
    {
        Debug.Log("InitializeComponents called");
        cartEmitter = AudioManager.instance.InitializeEventEmitter(FMODEvents.instance.Cart, gameObject);
        playerProgression = FindObjectOfType<PlayerProgression>();
        xrLever = FindObjectOfType<XRLever>();
        //engineTemperature = FindObjectOfType<EngineTemperature>();
        initialLeverValue = xrLever.GetLeverValue();
        previousValue = initialLeverValue;
        Debug.Log($"Initial Lever Value: {initialLeverValue}");
    }

    private void InitializeAudioInstances()
    {
        Debug.Log("InitializeAudioInstances called");
        leverInstance = AudioManager.instance.CreateInstance(FMODEvents.instance.Lever);
        engineHeatInstance = AudioManager.instance.CreateInstance(FMODEvents.instance.EngineHeat);
        engineHeatInstance.start();
        engineHeatInstance.release();
        cartEmitter.Play();
        cartEmitter.EventInstance.release();
        leverInstance.start();
        leverInstance.release();
        leverInstance.setPaused(true);
        Debug.Log("Audio instances initialized and started");
    }

    private void UpdateSoundLogic()
    {
        Debug.Log("UpdateSoundLogic called");
        UpdateThrottleSound();
        UpdateBrakeSound();
        UpdateCartMovementSound();
        UpdateEngineHeatSound();

        leverPosition = xrLever.GetLeverValue();
        isUserInteracting = xrLever.GetLeverInteracting();

        //Debug.Log($"Lever Position: {leverPosition}, Is User Interacting: {isUserInteracting}");
    }

    private float GetRotationStrength(float currentRotation, float previousRotation)
    {
        float rotationDifference = Mathf.Abs(currentRotation - previousRotation);
        float maxRotationDifference = 1.0f - deadzone;
        float normalizedDifference = Mathf.Clamp01(rotationDifference / maxRotationDifference);
        //Debug.Log($"Rotation Strength: {normalizedDifference * Mathf.Sign(currentRotation - previousRotation)}");
        return normalizedDifference * Mathf.Sign(currentRotation - previousRotation);
    }

    private void UpdateThrottleSound()
    {
        rotationStrength = GetRotationStrength(leverPosition, previousValue);
        if (isUserInteracting)
        {
            HandleLeverInteraction(leverPosition);
        }
        else
        {
            StopLeverSound();
        }
        previousValue = leverPosition;
    }

    private void HandleLeverInteraction(float input)
    {
        hasSignificantChange = Mathf.Abs(rotationStrength) > threshold;

        if ((leverPosition == 0f || leverPosition == 1f) && !hasEndPlayed)
        {
            AudioManager.instance.PlayOneShot(FMODEvents.instance.LeverEnds, transform.position);
            hasEndPlayed = true;
            Debug.Log($"Played LeverEnd sound at position: {leverPosition}");
        }
        else if (leverPosition != 0f || leverPosition != 1f && leverPosition > 0.9f)
        {
            hasEndPlayed = false;
            Debug.Log("Reset LeverEnd played state");
        }

        if (hasSignificantChange && !isPlaying)
        {
            AudioManager.instance.SetInstanceParameter(leverInstance, "LeverForce", leverPosition);
            leverInstance.setPaused(false);
            isPlaying = true;
            Debug.Log("Start lever sound");
        }
        else if (!hasSignificantChange && isPlaying)
        {
            StopLeverSound();
        }
    }

    private void StopLeverSound()
    {
        if (isPlaying)
        {
            leverInstance.setPaused(true);
            isPlaying = false;
            Debug.Log("Stop lever sound");
        }
    }

    private void UpdateBrakeSound()
    {
        if (isUserInteracting && !isAtDefaultPosition)
        {
            HandleBrakeInteraction();
        }
        else if (leverPosition != initialLeverValue)
        {
            isAtDefaultPosition = false;
        }
    }

    private void HandleBrakeInteraction()
    {
        if (leverPosition == 0 && !brakeOn && smoothedSpeed > 0.4f)
        {
            AudioManager.instance.PlayOneShot(FMODEvents.instance.Brake, transform.position);
            brakeOn = true;
            Debug.Log("Played brake sound");
        }
        else if (leverPosition > 0.4f)
        {
            brakeOn = false;
        }
    }

    private void UpdateCartMovementSound()
    {
        float progression = playerProgression.GetProgression();
        float speedThreshold = 0.2f;
        float targetRattle = 0f;
        float waterfallFade = 1f;

        speed = leverPosition;
        smoothedSpeed = Mathf.Lerp(smoothedSpeed, speed, smoothSpeedFactor);
        Debug.Log($"Smoothed Speed: {smoothedSpeed} , leverpos: {leverPosition}");

        if (progression > 12 && progression < 17)
        {
            targetRattle = 1f;
        }
        else if (smoothedSpeed >= speedThreshold)
        {
            targetRattle = Mathf.Lerp(0f, 0.5f, (smoothedSpeed - speedThreshold) / (1f - speedThreshold));
        }

        rattle = Mathf.Lerp(rattle, targetRattle, Time.deltaTime * waterfallFade);
        Debug.Log($"Rattle: {rattle}");

        if (Mathf.Abs(rattle) < 0.0001f)
        {
            rattle = 0f;
        }

        AudioManager.instance.SetEmitterParameter(cartEmitter, "Rattle", rattle);
        AudioManager.instance.SetEmitterParameter(cartEmitter, "Cart Speed", smoothedSpeed);
    }

    private void UpdateEngineHeatSound()
    {
        float tempAngle = engineheat.GetEngineTemperature();
        float minValue = -90f;
        float maxValue = 90f;
        float normalizedValue = (tempAngle - minValue) / (maxValue - minValue);

        AudioManager.instance.SetInstanceParameter(engineHeatInstance, "EngineHeatVal", normalizedValue);
        Debug.Log($"Engine Heat Value: {normalizedValue}");
    }

    void OnDestroy()
    {
        Debug.Log("OnDestroy called");
        cartEmitter.Stop();
        engineHeatInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        leverInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }
}
