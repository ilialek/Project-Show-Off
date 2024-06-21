using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using System.Runtime.CompilerServices;


public class CartBehaviour : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private Vector3 cartStartPoint;
    [SerializeField] private Vector3 cartEndPoint;

    [SerializeField] private float force;
    [SerializeField] private ParticleSystem particleSystem;

    bool workonce = false;
    public float leverValue = 0;

    private bool isGameOver = false;

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
    }

    public void OnGameOver()
    {
        force = 0;
        isGameOver = true;
    }

    public void OnTheEnd()
    {
        force = 0;
    }
}

