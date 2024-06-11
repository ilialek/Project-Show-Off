using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class CartBehaviour : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private Vector3 cartStartPoint;
    [SerializeField] private Vector3 cartEndPoint;

    [SerializeField] private float force;
    [SerializeField] private ParticleSystem particleSystem;

    private FMOD.Studio.EventInstance Cart;

    bool workonce = false;

    private float speed;
    private float smoothedSpeed;
    [SerializeField, Range(0.01f, 1f)] private float smoothSpeedFactor = 0.1f;

    public Vector3 CartStartPoint
    {
        get { return cartStartPoint; }
    }

    public Vector3 CartEndPoint
    {
        get { return cartEndPoint; }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cart = RuntimeManager.CreateInstance("event:/Cart");
        if (Cart.isValid())
        {
            Debug.Log("FMOD Event created successfully.");

            // Set the initial 3D attributes of the sound
            Set3DAttributes();

            // Start the FMOD event
            Cart.start();
            Debug.Log("FMOD Event started.");
        }
        else
        {
            Debug.LogError("Failed to create FMOD Event.");
        }
    }

    private void Update()
    {
        if (transform.position.z > -496)
        {
            if (particleSystem != null)
            {
                if (!workonce)
                    particleSystem.Play();
                workonce = true;
            }
            else
            {
                Debug.LogWarning("Particle System is not assigned.");
            }
        }

        if (UnityEngine.InputSystem.Keyboard.current.uKey.isPressed)
        {
            transform.Translate(Vector3.forward * 50 * Time.deltaTime);
        }
        if (UnityEngine.InputSystem.Keyboard.current.jKey.isPressed)
        {
            transform.Translate(Vector3.back * 50 * Time.deltaTime);
        }
        //Debug.Log("Smoothed Speed: " + smoothedSpeed);
        Cart.setParameterByName("Cart speed", smoothedSpeed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(Vector3.forward * force);
        speed = Mathf.Max(0, rb.velocity.magnitude);
        speed = Mathf.Clamp(speed, 0, 1);
        smoothedSpeed = Mathf.Lerp(smoothedSpeed, speed, smoothSpeedFactor);
    }


    void OnDestroy()
    {
        // Release the FMOD event instance
        Cart.release();
    }

    private void Set3DAttributes()
    {
        // Set the 3D attributes of the FMOD event instance to match the player's position
        FMOD.ATTRIBUTES_3D attributes = RuntimeUtils.To3DAttributes(transform.position);
        Cart.set3DAttributes(attributes);
    }
}
