using FMOD.Studio;
using FMODUnity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMonsterOrBatOrSomething : MonoBehaviour, IEventListener
{
    [SerializeField] private ProgressionTrigger threshold;
    private Renderer renderer;
    private AudioManager audioManager;

    void Start()
    {
        EventBus.Instance.Register(this);
        RideProgression.Instance.AddThreshold(threshold);
        renderer = GetComponent<Renderer>();

        // Initialize the audioManager instance
        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.LogError("AudioManager instance is not found in the scene.");
        }
    }

    public void OnEvent(Event e)
    {
        if (e is EventProgressionThresholdReached _e)
        {
            if (_e.threshold == threshold.threshold)
            {
                renderer.material.SetColor("_BaseColor", Color.green);
                

                // Play the Bats one-shot sound using FMODEvents singleton
                if (audioManager != null)
                {
                    Debug.Log("BATS");
                    audioManager.PlayOneShot(FMODEvents.instance.Bats, transform.position);
                }

                StartCoroutine(ChangeColorBack());
            }
        }
    }

    private IEnumerator ChangeColorBack()
    {
        yield return new WaitForSeconds(0.1f);
        renderer.material.SetColor("_BaseColor", Color.white);
    }
}
