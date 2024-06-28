using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Experimental.GlobalIllumination;
using FMODUnity;
using FMOD.Studio;

public class LightBehaviour : MonoBehaviour, IEventListener
{
    [SerializeField] private float lightingDuration;
    [SerializeField] private float preSoundDelay;
    [SerializeField] private LayerMask detectableLayer;

    [SerializeField]
    private Transform joystickTransform;

    private bool lightIsSet = false;
    private bool coroutineStarted = false;

    private Light lightComponent;

    private float blinkInterval = 1.0f; // Interval between blinks in seconds
    private bool isOn = true; // Track if the light is on or off
    private float timer = 0f;

    private float knobValue = 0;

    private bool isAwaitingLight = false;

    void Start()
    {
        EventBus.Instance.Register(this);
        lightComponent = GetComponent<Light>();
        lightComponent.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        SetTheRotation();

        DetectObjects();
        if (!lightIsSet)
        {
            if (knobValue > 0 && knobValue < 1)
            {
                BlinkingBehaviour();
            }
            else if (knobValue == 1)
            {
                lightComponent.enabled = true;
                lightIsSet = true;
            }
            else if (knobValue == 0)
            {
                lightComponent.enabled = false;
            }
        }
        else
        {
            if (!coroutineStarted)
            {
                StartCoroutine(LightingCoroutine());
                coroutineStarted = true;
            }
        }
    }

    IEnumerator LightingCoroutine()
    {
        yield return new WaitForSeconds(lightingDuration);
        yield return new WaitForSeconds(preSoundDelay);
        StartCoroutine(EndBlinkCoroutine());
    }

    IEnumerator EndBlinkCoroutine()
    {
        float totalTime = 0f;
        float blinkInterval = 0.05f; // Interval between blinks in seconds
        float blinkDuration = 1.6f; // Total duration of blinking in seconds
        while (totalTime < blinkDuration)
        {
            lightComponent.enabled = !lightComponent.enabled;

            yield return new WaitForSeconds(blinkInterval);

            totalTime += blinkInterval;
        }   
        // Ensure the light is on after the blinking is finished
        lightComponent.enabled = false;
        lightIsSet = false;
        coroutineStarted = false;
    }

    private void SetTheRotation()
    {
        transform.localEulerAngles = new Vector3(joystickTransform.localEulerAngles.x, joystickTransform.localEulerAngles.z, 0);
    }

    private void BlinkingBehaviour()
    {
        if (knobValue > 0)
        {
            blinkInterval = 1 / (knobValue * 17);
            //Debug.Log(blinkInterval.ToString());
        }
        timer += Time.deltaTime; // Increment the timer

        if (timer >= blinkInterval)
        {
            isOn = !isOn; // Toggle the light on/off
            //Debug.Log(timer);
            lightComponent.enabled = isOn; // Set the light's enabled state
            timer = 0f; // Reset the timer
        }      
    }

    void DetectObjects()
    {
        // Get all colliders within the spotlight's range
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, lightComponent.range * 0.6f, detectableLayer);

        foreach (Collider hitCollider in hitColliders)
        {
            Vector3 directionToTarget = hitCollider.transform.position - transform.position;
            float angleToTarget = Vector3.Angle(transform.forward, directionToTarget);

            if (angleToTarget < lightComponent.spotAngle / 2 && lightComponent.enabled)
            {
                // Object is within the spotlight's cone

               // Debug.Log("Detected object: " + hitCollider.name);

                Monster monsterScript = hitCollider.GetComponent<Monster>();

                if (monsterScript.currentState == MonsterState.Idle)
                {
                    monsterScript.SetState(MonsterState.Highlighted);
                }

                if (monsterScript.currentState == MonsterState.End)
                {
                    monsterScript.FinalHighlight();
                }

                if (isAwaitingLight)
                {
                    EventBus.Instance.Emit(new EventMonsterLit(hitCollider));
                    isAwaitingLight = false;
                }
            }
            
        }
    }

    public void IsLightSet(bool _value)
    {
        lightIsSet = _value;
    }
    public void ReceiveTheRotationValue(float _value)
    {
        knobValue = _value;
    }

    public float GetKnobValue() => knobValue;

    public bool GetLightState() => lightIsSet;

    public float GetBlinkInterval() => blinkInterval;

    public bool GetCoroutineState() => coroutineStarted;

    public float GetLightDuration() => lightingDuration;

    public float GetPreDelay() => preSoundDelay;

    public bool GetOnState() => isOn;

    public void OnEvent(Event e)
    {
        if (e is EventLightRequiredZoneEntered)
        {
            isAwaitingLight = true;
        }
    }
}

public class EventMonsterLit : Event 
{
    public Collider monsterCollider;

    public EventMonsterLit(Collider _monsterCollider)
    {
        monsterCollider = _monsterCollider;
    }
}