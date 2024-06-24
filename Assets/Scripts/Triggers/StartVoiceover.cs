using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartVoiceover : MonoBehaviour, IEventListener
{
    [SerializeField] ProgressionTrigger trigger;
    [SerializeField] CartBehaviour cart;

    public void OnEvent(Event e)
    {
        if (e is EventProgressionThresholdReached _e)
        {
            if (_e.threshold == trigger.threshold)
            {
                // Trigger Voiceover here
                print("Trigger Voiceover here");
            }
        }
    }

    void Start()
    {
        EventBus.Instance.Register(this);
        RideProgression.Instance.AddThreshold(trigger);
    }
}
