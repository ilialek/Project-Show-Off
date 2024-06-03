using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMonsterOrBatOrSomething : MonoBehaviour, IEventListener
{
    [SerializeField] private ProgressionTrigger threshold;
    private Renderer renderer;

    void Start()
    {
        EventBus.Instance.Register(this);
        RideProgression.Instance.AddThreshold(threshold);
        renderer = GetComponent<Renderer>();
    }

    public void OnEvent(Event e)
    {
        if (e is EventProgressionThresholdReached _e)
        {
            if (_e.threshold == threshold.threshold)
            {
                renderer.material.SetColor("_BaseColor", Color.green);
                Debug.Log("Green Flash");
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
