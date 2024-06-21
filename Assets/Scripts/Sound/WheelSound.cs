using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using XRKnob = UnityEngine.XR.Content.Interaction.XRKnob;

public class WheelSound : MonoBehaviour
{
    private EventInstance backspinInstance;
    private StudioEventEmitter wheelChargeEmitter;

    private bool isWheelChargePlaying = false;
    private bool isBackspinPlaying = false;
    private bool isUserInteracting = false;
    private float rotation;
    private float previousRotation;

    [SerializeField]
    private float RotationThreshold = 0.1f;

    private bool isRotationChanging = false;
    private bool hasPlayedWheelNull = true;

    private float previousValue;
    private float previousTime;
    public float rateOfChange;
    private float smoothedRateOfChange;

    private XRKnob XRKnob;

    void Start()
    {
        backspinInstance = AudioManager.instance.CreateInstance(FMODEvents.instance.Backspin);
        wheelChargeEmitter = gameObject.AddComponent<StudioEventEmitter>();

        wheelChargeEmitter = AudioManager.instance.InitializeEventEmitter(FMODEvents.instance.WheelRotation, gameObject);
        wheelChargeEmitter.PlayEvent = EmitterGameEvent.None;
        wheelChargeEmitter.StopEvent = EmitterGameEvent.None;

        XRKnob = FindObjectOfType<XRKnob>();
        wheelChargeEmitter.Play(); // Start playing the emitter but keep it paused initially
        wheelChargeEmitter.EventInstance.setPaused(true);

        backspinInstance.start();
        backspinInstance.release();
        backspinInstance.setPaused(true);

        previousValue = Mathf.Clamp(XRKnob.GetTheYRotationInDegrees(), 0f, 1f);
        previousTime = Time.time;
    }

    private void FixedUpdate()
    {
        rotation = XRKnob.GetTheYRotationInDegrees();
        HandleSoundLogic();
        WheelVelocity();
    }

    void WheelVelocity()
    {
        float normalizedRotation = NormalizeRotation(rotation);
        float rotationSpeed = Mathf.Clamp(normalizedRotation, 0f, 1f);
        float currentTime = Time.time;
        float currentValue = rotationSpeed;
        float deltaValue = currentValue - previousValue;
        float deltaTime = currentTime - previousTime;

        if (deltaTime > 0)
        {
            rateOfChange = deltaValue / deltaTime;
        }

        smoothedRateOfChange = Mathf.Lerp(smoothedRateOfChange, rateOfChange, 0.1f);
        smoothedRateOfChange = Mathf.Clamp(smoothedRateOfChange, 0f, 1f);
        previousValue = currentValue;
        previousTime = currentTime;

        AudioManager.instance.SetEmitterParameter(wheelChargeEmitter, "WheelForce", smoothedRateOfChange);
    }

    private float NormalizeRotation(float rotation)
    {
        return Mathf.InverseLerp(0f, 360f, rotation);
    }

    private void PlayWheelChargeSound()
    {
        if (!isWheelChargePlaying && wheelChargeEmitter.EventInstance.isValid())
        {
            wheelChargeEmitter.EventInstance.setPaused(false);
            isWheelChargePlaying = true;
        }
    }

    private void PlayBackspinSound()
    {
        if (!isBackspinPlaying && backspinInstance.isValid())
        {
            backspinInstance.setPaused(false);
            isBackspinPlaying = true;
        }
    }

    private void StopAndReleaseWheelChargeSound()
    {
        if (isWheelChargePlaying && wheelChargeEmitter.EventInstance.isValid())
        {
            wheelChargeEmitter.EventInstance.setPaused(true);
            isWheelChargePlaying = false;
        }
    }

    private void StopAndReleaseBackspinSound()
    {
        if (isBackspinPlaying && backspinInstance.isValid())
        {
            backspinInstance.setPaused(true);
            isBackspinPlaying = false;
        }
    }

    private void HandleSoundLogic()
    {
        isUserInteracting = XRKnob.GetUserState();
        isRotationChanging = Mathf.Abs(rotation - previousRotation) > RotationThreshold;
        //Debug.Log($"Radical Change! Current: {rotation}, Previous: {previousRotation}, Difference: {Math.Abs(rotation - previousRotation)}");

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
        }
        else
        {
            StopAndReleaseWheelChargeSound();
            StopAndReleaseBackspinSound();
        }

        previousRotation = rotation;
    }
}