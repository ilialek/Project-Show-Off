using FMOD.Studio;
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

    private float previousValue;
    private float previousTime;
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

    private void FixedUpdate()
    {
        rotation = XRKnob.GetTheYRotationInDegrees();
        
        HandleSoundLogic();
        WheelVelocity();
    }

    void WheelVelocity()
    {
        float normalizedRotation = NormalizeRotation(rotation);
        float rotationspeed = Mathf.Clamp(normalizedRotation, 0f, 1f);
        float currentTime = Time.time;
        float currentValue = rotationspeed;
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

        AudioManager.instance.SetInstanceParameter(wheelChargeInstance, "WheelForce", smoothedRateOfChange);
    }

    private float NormalizeRotation(float rotation)
    {
        return Mathf.InverseLerp(0f, 360f, rotation);
    }

    private void PlayWheelChargeSound()
    {
        if (!isWheelChargePlaying && wheelChargeInstance.isValid())
        {
            wheelChargeInstance.setPaused(false);
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
        if (isWheelChargePlaying && wheelChargeInstance.isValid())
        {
            wheelChargeInstance.setPaused(true);
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
        isRotationChanging = Mathf.Abs(rotation - previousRotation) > RotationTreshold;
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
