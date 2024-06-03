using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lantern : MonoBehaviour
{
    [Tooltip("time it takes for fully charged lamp to discharge fully, in seconds")]
    [SerializeField] private float dischargeTime = 5.0f; 

    private Keyboard keyboard;
    private float charge = 1.0f;
    private Renderer lampRenderer;

    void Start()
    {
        keyboard = Keyboard.current;
        lampRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        UpdateCharge();

        if (keyboard[Key.Digit1].wasPressedThisFrame)
        {
            charge = 1.0f;
            Debug.Log("Lamp Relit");
        }

        UpdateLampColor();
    }

    void UpdateCharge()
    {
        if (charge > 0) 
        {
            charge -= Time.deltaTime / dischargeTime;
            if (charge <= 0)
            {
                charge = 0;
                Debug.Log("Lamp Gone Out");
                EventBus.Instance.Emit(new EventLanternGoneOut());
            }
        }
    }

    void UpdateLampColor()
    {
        Color color = Color.Lerp(Color.green, Color.red, 1 - charge);
        lampRenderer.material.SetColor("_BaseColor", color); 
    }
}

public class EventLanternGoneOut : Event {}