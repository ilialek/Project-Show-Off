using FMOD.Studio;
using FMODUnity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class CartSound : MonoBehaviour
{
    private float speed;
    private float smoothedSpeed;
    private float rattle;

    [SerializeField, Range(0.01f, 1f)] private float smoothSpeedFactor = 0.1f;

    private PlayerProgression playerProgression;
    private XRLever XRLever;
    private EngineTemperature EngineTemperature;
    private StudioEventEmitter Cartemitter;
    private float previousValue;
    private EventInstance leverInstance;
    private EventInstance brakeInstance;
    private EventInstance engineHeatInstance;

    private float rotationStrength;
    private bool isPlaying;
    private bool brakeOn = false;

    private float initialLeverValue;

    private bool isAtDefaultPosition = true;

    private Vector3 lookDirection;

    [SerializeField, Range(0.01f, 1f)] private float threshold = 0.01f; //this much change is needed in order to detect the lever moving

    [SerializeField, Range(0.01f, 1f)] private float deadzone = 0.01f; //set deadzone for max rotation values

    // Start is called before the first frame update
    void Start()
    {
        Cartemitter = AudioManager.instance.InitializeEventEmitter(FMODEvents.instance.Cart, gameObject);
        leverInstance = AudioManager.instance.CreateInstance(FMODEvents.instance.Lever);
        brakeInstance = AudioManager.instance.CreateInstance(FMODEvents.instance.Brake);
        engineHeatInstance = AudioManager.instance.CreateInstance(FMODEvents.instance.EngineHeat);
        engineHeatInstance.start();
        Cartemitter.Play();
        playerProgression = FindObjectOfType<PlayerProgression>();
        XRLever = FindObjectOfType<XRLever>();
        EngineTemperature = FindObjectOfType<EngineTemperature>();
        initialLeverValue = XRLever.GetLeverValue();
        Debug.Log("Initial Look Direction: " + XRLever.GetLookDirection());
    }

    private void FixedUpdate()
    {
        SoundLogic();
    }

    //CHECKING HOW FAST THE LEVER IS BEING MOVED
    private float GetRotationStrength(float currentRotation, float previousRotation)
    {
        float rotationDifference = Mathf.Abs(currentRotation - previousRotation);
        float maxRotationDifference = 1.0f - deadzone; // Adjust for deadzone
        float normalizedDifference = Mathf.Clamp01(Mathf.Abs(rotationDifference) / maxRotationDifference); // Normalize to 0-1 considering deadzone
        return normalizedDifference * Mathf.Sign(currentRotation - previousRotation); // Preserve movement direction
    }

    //UGLY AHH METHOD HANDLING MOST OF THE LOGIC
    private void SoundLogic()
    {
        // Determine the target rattle based on conditions
        float speedThreshold = 0.2f; // Adjust this threshold to control when rattle starts
        float targetRattle = 0f;
        float waterfallFade = 1f;
        float progression = playerProgression.GetProgression();
        bool isUserInteracting = XRLever.GetLeverInteracting();
        float leverValue = XRLever.GetLeverValue();

        float rotationStrengthRaw = GetRotationStrength(lookDirection.z, previousValue);
        rotationStrength = Math.Abs(rotationStrengthRaw);

        //LOGIC FOR THROTTLE SOUND
        if (isUserInteracting)
        {
            bool hasSignificantChange = Mathf.Abs(rotationStrength - previousValue) > threshold;
            //Debug.Log("Rotation Strength: " + rotationStrength + ", Previous Value: " + previousValue + "HasChange: " + hasSignificantChange);
            if (hasSignificantChange && !isPlaying)
            {
                hasSignificantChange = Mathf.Abs(rotationStrength - previousValue) > threshold;
                //previousValue = rotationStrength;
                AudioManager.instance.SetInstanceParameter(leverInstance, "LeverForce", rotationStrength);
                leverInstance.start();
                isPlaying = true;
                Debug.Log("startsound");     
            }
            else if (!hasSignificantChange && isPlaying)
            {
                leverInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                isPlaying = false;
                Debug.Log("stopwhileinteraction");
            }
            previousValue = rotationStrength;
        }
        else
        {
            if (isPlaying)
            {
                leverInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                isPlaying = false;
                Debug.Log("stop");        
            }
            previousValue = 0f;
        }

        //LOGIC FOR THE BREAK/STOP SOUND
        if (isUserInteracting && !isAtDefaultPosition)
        {
            lookDirection = XRLever.GetLookDirection();
            
            if (lookDirection.z < 0 && !brakeOn && isUserInteracting &&lookDirection.y < 0.4f)  // Lever pulled back
            {
                brakeInstance.start();
                brakeOn = true;
            }
            else if ((lookDirection.z >= 0 || !isUserInteracting) && brakeOn)  // Lever pushed forward or no interaction
            {
                brakeInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                brakeOn = false;
            }
        } else if (leverValue != initialLeverValue)
        {
            isAtDefaultPosition = false;
        }

        //CART MOVEMENT RELATED STUFF
        speed = leverValue;
        smoothedSpeed = Mathf.Lerp(smoothedSpeed, speed, smoothSpeedFactor);

        //CART UNDER WATERFALL HARDCODED
        if (progression > 12 && progression < 17)
        {
            targetRattle = 1f;
        }
        else
        {
            if (smoothedSpeed >= speedThreshold)
            {
                targetRattle = Mathf.Lerp(0f, 0.5f, (smoothedSpeed - speedThreshold) / (1f - speedThreshold));
            }
        }
        rattle = Mathf.Lerp(rattle, targetRattle, Time.deltaTime * waterfallFade);

        if (Mathf.Abs(rattle) < 0.0001f)
        {
            rattle = 0f;
        }

        // Uncomment these lines if needed to set the emitter parameters
        AudioManager.instance.SetEmitterParameter(Cartemitter, "Rattle", rattle);
        AudioManager.instance.SetEmitterParameter(Cartemitter, "Cart Speed", smoothedSpeed);

        float tempAngle = EngineTemperature.GetEngineTemperature();
        float minValue = -90f;
        float maxValue = 90f;

        float normalizedValue = (tempAngle - minValue) / (maxValue - minValue);
        AudioManager.instance.SetInstanceParameter(engineHeatInstance, "EngineHeatVal", normalizedValue);
        engineHeatInstance.getParameterByName("EngineHeatVal", out float changedParamValue);

        Debug.Log($"ChangedParamValue: {changedParamValue}");


        



    }

    void OnDestroy()
    {
        Cartemitter.Stop();
    }
}
