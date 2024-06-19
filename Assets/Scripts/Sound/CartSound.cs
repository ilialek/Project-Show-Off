using FMOD.Studio;
using FMODUnity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Content.Interaction;
using UnityEngine.Events;

public class CartSound : MonoBehaviour
{
    private float speed;
    private float smoothedSpeed;
    private float rattle;

    [SerializeField, Range(0.01f, 1f)] private float smoothSpeedFactor = 0.1f;

    private PlayerProgression playerProgression;
    private XRLever xrLever;
    private EngineTemperature engineTemperature;
    private StudioEventEmitter cartEmitter;

    private EventInstance leverInstance;
    private EventInstance brakeInstance;
    private EventInstance engineHeatInstance;
    private float rotationStrength;
    private bool isPlaying;
    private bool brakeOn = false;

    private float initialLeverValue;
    private float previousValue;
    private bool hasSignificantChange;
    private bool isAtDefaultPosition = true;
    private Vector3 lookDirection;
    bool isUserInteracting;

    private float leverPosition;

    [SerializeField, Range(0.001f, 1f)] private float threshold = 0.001f;
    [SerializeField, Range(0.01f, 0.1f)] private float deadzone = 0.01f;

    void Start()
    {
        InitializeComponents();
        InitializeAudioInstances();
    }

    private void FixedUpdate()
    {
        UpdateSoundLogic();
    }

    private void InitializeComponents()
    {
        cartEmitter = AudioManager.instance.InitializeEventEmitter(FMODEvents.instance.Cart, gameObject);
        playerProgression = FindObjectOfType<PlayerProgression>();
        xrLever = FindObjectOfType<XRLever>();
        engineTemperature = FindObjectOfType<EngineTemperature>();
        initialLeverValue = xrLever.GetLeverValue();
        Debug.Log("Initial Look Direction: " + xrLever.GetLookDirection());
        previousValue = initialLeverValue;
    }

    private void InitializeAudioInstances()
    {
        leverInstance = AudioManager.instance.CreateInstance(FMODEvents.instance.Lever);
        brakeInstance = AudioManager.instance.CreateInstance(FMODEvents.instance.Brake);
        engineHeatInstance = AudioManager.instance.CreateInstance(FMODEvents.instance.EngineHeat);
        engineHeatInstance.start();
        cartEmitter.Play();
        engineHeatInstance.release();
        cartEmitter.EventInstance.release();
        leverInstance.start(); leverInstance.release(); leverInstance.setPaused(true);
        brakeInstance.start(); brakeInstance.release(); brakeInstance.setPaused(true);
    }

    private void UpdateSoundLogic()
    {
        UpdateThrottleSound();
        UpdateBrakeSound();
        UpdateCartMovementSound();
        UpdateEngineHeatSound();

        leverPosition = xrLever.GetLeverValue();
        isUserInteracting = xrLever.GetLeverInteracting();
    }

    private float GetRotationStrength(float currentRotation, float previousRotation)
    {
        float rotationDifference = Mathf.Abs(currentRotation - previousRotation);
        float maxRotationDifference = 1.0f - deadzone;
        float normalizedDifference = Mathf.Clamp01(rotationDifference / maxRotationDifference);
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
        
        if (hasSignificantChange && !isPlaying)
        {
            
            leverInstance.setPaused(false);
            isPlaying = true;
            AudioManager.instance.SetInstanceParameter(leverInstance, "LeverForce", leverPosition);
            //Debug.Log("Start lever sound");
        }
        else if (!hasSignificantChange && isPlaying)
        {
            StopLeverSound();
            //Debug.Log("Stop lever sound while interacting");
        }
    }

    private void StopLeverSound()
    {
        if (isPlaying)
        {
            leverInstance.setPaused(true);
            isPlaying = false;
            //Debug.Log("Stop lever sound");
        }
    }

    private void UpdateBrakeSound()
    {

        if (isUserInteracting && !isAtDefaultPosition)
        {
            lookDirection = xrLever.GetLookDirection();
            HandleBrakeInteraction();
        }
        else if (leverPosition != initialLeverValue)
        {
            isAtDefaultPosition = false;
        }
    }

    private void HandleBrakeInteraction()
    {
        if (lookDirection.z < 0 && !brakeOn && lookDirection.y < 0.4f)
        {
            brakeInstance.setPaused(false);
            brakeOn = true;
        }
        else if ((lookDirection.z >= 0 || !brakeOn) && brakeOn)
        {
            brakeInstance.setPaused(true);
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

        if (progression > 12 && progression < 17)
        {
            targetRattle = 1f;
        }
        else if (smoothedSpeed >= speedThreshold)
        {
            targetRattle = Mathf.Lerp(0f, 0.5f, (smoothedSpeed - speedThreshold) / (1f - speedThreshold));
        }

        rattle = Mathf.Lerp(rattle, targetRattle, Time.deltaTime * waterfallFade);

        if (Mathf.Abs(rattle) < 0.0001f)
        {
            rattle = 0f;
        }

        AudioManager.instance.SetEmitterParameter(cartEmitter, "Rattle", rattle);
        AudioManager.instance.SetEmitterParameter(cartEmitter, "Cart Speed", smoothedSpeed);
    }

    private void UpdateEngineHeatSound()
    {
        float tempAngle = engineTemperature.GetEngineTemperature();
        float minValue = -90f;
        float maxValue = 90f;

        float normalizedValue = (tempAngle - minValue) / (maxValue - minValue);
        AudioManager.instance.SetInstanceParameter(engineHeatInstance, "EngineHeatVal", normalizedValue);
        engineHeatInstance.getParameterByName("EngineHeatVal", out float changedParamValue);

        //Debug.Log($"ChangedParamValue: {changedParamValue}");
    }

    void OnDestroy()
    {
        cartEmitter.Stop();
        engineHeatInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        leverInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        brakeInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }
}
