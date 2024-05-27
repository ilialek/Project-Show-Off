using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehaviour : MonoBehaviour
{
    [SerializeField] private float treshold;

    public float handVelocity;
    public bool isStarterBeingGrabbed;

    private Light lightComponent;
    void Start()
    {
        lightComponent = GetComponent<Light>();
        lightComponent.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStarterBeingGrabbed)
        {
            if (handVelocity >= treshold)
            {
                lightComponent.enabled = true;
            }
        }
    }
}
