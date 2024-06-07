using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartBehaviour : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float force;
    [SerializeField] private ParticleSystem particleSystem;

    bool workonce = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (transform.position.z > -510)
        {
            if (particleSystem != null)
            {
                if(!workonce)
                particleSystem.Play();
                workonce = true;
            }
            else
            {
                Debug.LogWarning("Particle System is not assigned.");
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(Vector3.forward * force);
    }
}
