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
    private float rateOfChange;
    public float smoothedRateOfChange;

    private XRKnob XRKnob;

    private GameObject Wheel;

    void Start()
    {
        backspinInstance = AudioManager.instance.CreateInstance(FMODEvents.instance.Backspin);
        wheelChargeEmitter = gameObject.AddComponent<StudioEventEmitter>();

        wheelChargeEmitter = AudioManager.instance.InitializeEventEmitter(FMODEvents.instance.WheelRotation, gameObject);

        Wheel = GameObject.Find("Part To Rotate");
        

        XRKnob = FindObjectOfType<XRKnob>();
        wheelChargeEmitter.Play();
        wheelChargeEmitter.EventInstance.release();
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
        isUserInteracting = XRKnob.GetUserState();

        HandleSoundLogic();
 
    }

    void WheelVelocity()
    {
        float normalizedRotation = NormalizeRotation(rotation);
        float rotationSpeed = Mathf.Clamp(normalizedRotation, 0f, 1f);
        float currentTime = Time.time;
        float currentValue = rotationSpeed;
        float deltaValue = currentValue - previousValue;
        float deltaTime = currentTime - previousTime;

        // Wrap-around correction for the rotation values
        if (deltaValue > 0.5f) deltaValue -= 1.0f;
        if (deltaValue < -0.5f) deltaValue += 1.0f;

        if (deltaTime > 0)
        {
            rateOfChange = deltaValue / deltaTime;
        }

        if (Mathf.Abs(rateOfChange) > 0.01f) // Apply smoothing only if rateOfChange is significant
        {
            smoothedRateOfChange = Mathf.Lerp(smoothedRateOfChange, rateOfChange, 0.1f);
            smoothedRateOfChange = Mathf.Clamp(smoothedRateOfChange, 0f, 1f);
        }

        //AudioManager.instance.SetEmitterParameter(wheelChargeEmitter, "WheelForce", smoothedRateOfChange);

        previousValue = currentValue;
        previousTime = currentTime;

        // Debug log for tracing values
        //Debug.Log($"WheelVelocity - currentValue: {currentValue}, deltaValue: {deltaValue}, rateOfChange: {rateOfChange}, smoothedRateOfChange: {smoothedRateOfChange}");
    }

    private float NormalizeRotation(float rotation)
    {
        return Mathf.InverseLerp(0f, 1080f, rotation);
    }

    private void PlayWheelChargeSound()
    {
        if (!isWheelChargePlaying && wheelChargeEmitter.EventInstance.isValid())
        {
            WheelVelocity();
            wheelChargeEmitter.EventInstance.setPaused(false);
            isWheelChargePlaying = true;
            //Debug.Log("Unpause");
        }
    }

    private void PlayBackspinSound()
    {
        if (!isBackspinPlaying && backspinInstance.isValid())
        {
            backspinInstance.setPaused(false);
            isBackspinPlaying = true;
            backspinInstance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform, Wheel.GetComponent<Rigidbody>()));
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
        isRotationChanging = Mathf.Abs(rotation - previousRotation) > RotationThreshold;

        if (isUserInteracting && rotation > 0.1f && isRotationChanging)
        {
            if (!isWheelChargePlaying)
            {
                PlayWheelChargeSound();
            }
            StopAndReleaseBackspinSound();
            hasPlayedWheelNull = false;
        }
        else if (rotation > 0.1f && isRotationChanging)
        {
            if (!isBackspinPlaying)
            {
                PlayBackspinSound();
            }
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