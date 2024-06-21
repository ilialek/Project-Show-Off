using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEnd : MonoBehaviour, IEventListener
{
    [SerializeField] ProgressionTrigger trigger;
    [SerializeField] CartBehaviour cart;

    public void OnEvent(Event e)
    {
        if (e is EventProgressionThresholdReached _e)
        {
            if (_e.threshold == trigger.threshold)
            {
                print("The end");
                cart.OnTheEnd();
            }
        }
    }

    void Start()
    {
        EventBus.Instance.Register(this);
        RideProgression.Instance.AddThreshold(trigger);
    }
}
