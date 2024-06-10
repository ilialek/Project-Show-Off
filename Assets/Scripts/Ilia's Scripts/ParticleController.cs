using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    // Reference to the Particle System component
    public ParticleSystem particleSystem;

    void Start()
    {
        // Start the Particle System
        if (particleSystem != null)
        {
            particleSystem.Play();
        }
        else
        {
            Debug.LogWarning("Particle System is not assigned.");
        }
    }

    // Optionally, you can create a method to start the Particle System on demand
    public void StartParticleSystem()
    {
        if (particleSystem != null)
        {
            particleSystem.Play();
        }
        else
        {
            Debug.LogWarning("Particle System is not assigned.");
        }
    }
}
