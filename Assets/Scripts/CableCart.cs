using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CableCart : MonoBehaviour, IEventListener
{
    [Tooltip("time to complete ride, in seconds")]
    [SerializeField] private float rideTime = 10.0f;

    private float speed = 2f;
    private bool isEnabled = false;
    private float movementInput;
    private Keyboard keyboard;
    private Renderer cartRenderer; 

    void Start()
    {
        EventBus.Instance.Register(this);
        RideTimer.Instance.AddThreshold(rideTime);
        keyboard = Keyboard.current;
        cartRenderer = GetComponent<Renderer>(); 
    }

    void Update()
    {
        if (keyboard.eKey.wasPressedThisFrame)
        {
            if (!isEnabled)
            {
                isEnabled = true;
                EventBus.Instance.Emit(new EventCableCartStarted());
                cartRenderer.material.SetColor("_BaseColor", Color.green);
                Debug.Log("Cable Cart Started");
            }
        }

        MoveCart();
    }

    private void MoveCart()
    {
        if (!isEnabled) return;

        movementInput = keyboard[Key.W].ReadValue() - keyboard[Key.S].ReadValue();
        transform.Translate(Vector3.right * speed * movementInput * Time.deltaTime);

        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -2f, 2f);
        transform.position = clampedPosition;
    }

    public void OnEvent(Event e)
    {
        if (e is EventTimerThresholdReached _e)
        {
            if (_e.threshold == rideTime)
            {
                cartRenderer.material.SetColor("_BaseColor", Color.red);
                isEnabled = false;
                Debug.Log("Run out of time");
            }
        }
    }
}

public class EventCableCartStarted : Event { }
