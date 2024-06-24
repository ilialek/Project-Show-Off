using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartBreakpoints : MonoBehaviour, IEventListener
{
    [SerializeField] CartBehaviour cart;

    [SerializeField] ProgressionTrigger trigger;



    void Start()
    {
        EventBus.Instance.Register(this);
        RideProgression.Instance.AddThreshold(trigger);
        
    }

    public void OnEvent(Event e)
    {
        if (e is EventProgressionThresholdReached _e)
        {
            if (_e.threshold == trigger.threshold)
            {
                cart.PlayBreakAnimation();
                print("Cart Breaks");
            }
        }
    }


}
