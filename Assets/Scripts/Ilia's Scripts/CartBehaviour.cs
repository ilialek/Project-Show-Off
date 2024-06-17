using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using System.Runtime.CompilerServices;


[RequireComponent(typeof(StudioEventEmitter))]
public class CartBehaviour : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private Vector3 cartStartPoint;
    [SerializeField] private Vector3 cartEndPoint;

    [SerializeField] private float force;
    [SerializeField] private ParticleSystem particleSystem;

    

    bool workonce = false;

    private float speed;
    private float smoothedSpeed;
    private float waterfallFade;
    private float rattle;
    private bool isUnderWaterfall;
    [SerializeField, Range(0.01f, 1f)] private float smoothSpeedFactor = 0.1f;

    private PlayerProgression playerProgression;
    private StudioEventEmitter Cartemitter;


    public float leverValue = 0;

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

        playerProgression = FindObjectOfType<PlayerProgression>();

        Cartemitter = AudioManager.instance.InitializeEventEmitter(FMODEvents.instance.Cart, gameObject);
        Cartemitter.Play();
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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(Vector3.forward * force * leverValue);
        SoundLogic();
    }

    private void SoundLogic()
    {
        speed = Mathf.Max(0, rb.velocity.magnitude);
        speed = Mathf.Clamp(speed, 0, 1);
        smoothedSpeed = Mathf.Lerp(smoothedSpeed, speed, smoothSpeedFactor);

        // Determine the target rattle based on conditions
        float speedThreshold = 0.2f; // Adjust this threshold to control when rattle starts
        float targetRattle = 0f;
        float progression = playerProgression.GetProgression();
        waterfallFade = 1f;

        if (progression > 13 && progression < 18)
        {
            // If under waterfall, set maximum rattle
            targetRattle = 1f;
        }
        else
        {
            // Otherwise, calculate rattle based on smoothedSpeed and speedThreshold
            if (smoothedSpeed >= speedThreshold)
            {
                targetRattle = Mathf.Lerp(0f, 0.5f, (smoothedSpeed - speedThreshold) / (1f - speedThreshold));
            }
        }

        // Apply the waterfall fade factor for smooth interpolation
        rattle = Mathf.Lerp(rattle, targetRattle, Time.deltaTime * waterfallFade);

        // Apply a small tolerance check to avoid extremely small rattle values
        if (Mathf.Abs(rattle) < 0.0001f)
        {
            rattle = 0f;
        }

        //Debug.Log($"SoundLogic - Speed: {speed}, Smoothed Speed: {smoothedSpeed}, Target Rattle: {targetRattle}, Rattle: {rattle}, Progression: {progression}");

        // Ensure the emitter is valid before setting parameters
        if (Cartemitter != null)
        {
            AudioManager.instance.SetEmitterParameter(Cartemitter, "Rattle", rattle);
            AudioManager.instance.SetEmitterParameter(Cartemitter, "Cart Speed", smoothedSpeed);
        }
        else
        {
            Debug.LogError("Cart emitter is null.");
        }
    }

    void OnDestroy()
    {
        Cartemitter.Stop();
    }
}
