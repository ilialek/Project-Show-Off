using UnityEngine;
using FMODUnity;
using UnityEngine.XR.Content.Interaction;

public class LeverSound : MonoBehaviour
{
    private XRLever xrLever;
    private StudioEventEmitter leverEmitter;
    private float rotationStrength;
    private bool isPlaying;
    private bool hasEndPlayed;
    private float leverPosition;
    private float previousValue;

    private GameObject Lever;

    [SerializeField, Range(0.001f, 1f)] private float threshold = 0.001f;
    [SerializeField] private float deadzone = 0.01f;

    void Start()
    {
        xrLever = FindObjectOfType<XRLever>();
        if (xrLever == null)
        {
            Debug.LogError("XRLever not found");
            return;
        }

        previousValue = xrLever.GetLeverValue();
        leverEmitter = AudioManager.instance.InitializeEventEmitter(FMODEvents.instance.Lever, gameObject);

        Lever = GameObject.Find("PIVOT");

        

    }

    void FixedUpdate()
    {
        leverEmitter.EventInstance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform, Lever.GetComponent<Rigidbody>()));

        UpdateSoundLogic();
    }

    private void UpdateSoundLogic()
    {
        
        bool isUserInteracting = xrLever.GetLeverInteracting();
        leverPosition = xrLever.GetLeverValue();
        rotationStrength = GetRotationStrength(leverPosition, previousValue);
        previousValue = leverPosition;

        if (isUserInteracting)
        {
            HandleLeverInteraction();
        }
        else
        {
            StopLeverSound();
        }
    }

    private float GetRotationStrength(float currentRotation, float previousRotation)
    {
        float rotationDifference = Mathf.Abs(currentRotation - previousRotation);
        float maxRotationDifference = 1.0f - deadzone;
        float normalizedDifference = Mathf.Clamp01(rotationDifference / maxRotationDifference);
        return normalizedDifference * Mathf.Sign(currentRotation - previousRotation);
    }

    private void HandleLeverInteraction()
    {
        bool hasSignificantChange = Mathf.Abs(rotationStrength) > threshold;
        leverPosition = Mathf.Clamp01(leverPosition);
        if ((leverPosition == 0f || leverPosition == 1f) && !hasEndPlayed)
        {
            AudioManager.instance.PlayOneShot(FMODEvents.instance.LeverEnds, transform.position);
            //Debug.Log("asd");
            hasEndPlayed = true;
        }
        else if (leverPosition > 0f && leverPosition < 1f)
        {
            hasEndPlayed = false;
        }

        if (hasSignificantChange && !isPlaying)
        {
            AudioManager.instance.SetEmitterParameter(leverEmitter, "LeverForce", leverPosition);
            leverEmitter.Play();
            leverEmitter.EventInstance.release();
            isPlaying = true;
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
            leverEmitter.EventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            isPlaying = false;
        }
    }

    public float GetLeverPosition()
    {
        return leverPosition;
    }
}