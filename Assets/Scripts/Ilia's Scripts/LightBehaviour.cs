using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LightBehaviour : MonoBehaviour
{
    [SerializeField] private float lightingDuration;

    private bool lightIsSet = false;
    private bool coroutineStarted = false;

    private Light lightComponent;

    private float blinkInterval = 1.0f; // Interval between blinks in seconds
    private bool isOn = true; // Track if the light is on or off
    private float timer = 0f;

    private float knobValue = 0;

    public TextMeshPro textMeshPro;

    void Start()
    {
        lightComponent = GetComponent<Light>();
        lightComponent.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (!lightIsSet)
        {

            if (knobValue > 0 && knobValue < 1)
            {
                BlinkingBehaviour();
            }
            else if (knobValue == 1)
            {
                //Debug.Log("worked");
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
    private void BlinkingBehaviour()
    {
        if (knobValue > 0)
        {
            blinkInterval = 1 / (knobValue * 17);
        }

        timer += Time.deltaTime; // Increment the timer

        if (timer >= blinkInterval)
        {
            isOn = !isOn; // Toggle the light on/off
            lightComponent.enabled = isOn; // Set the light's enabled state
            timer = 0f; // Reset the timer
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
}
