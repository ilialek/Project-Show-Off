using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRequiredZone : MonoBehaviour, IEventListener
{
    [SerializeField] CartBehaviour cart;

    [SerializeField] ProgressionTrigger entry;
    [SerializeField] ProgressionTrigger exit;

    private bool hasLit = false;

    void Start()
    {
        EventBus.Instance.Register(this);
        RideProgression.Instance.AddThreshold(entry);
        RideProgression.Instance.AddThreshold(exit);
    }

    public void OnEvent(Event e)
    {
        if (e is EventProgressionThresholdReached _e)
        {
            if (_e.threshold == entry.threshold)
            {
                EventBus.Instance.Emit(new EventLightRequiredZoneEntered());
            }
            if (_e.threshold == exit.threshold)
            {
                if (hasLit)
                {
                    print("lighgt ok");
                }
                else
                {
                    print("not ok");
                    cart.OnGameOver();
                }
            }
        }
        if (e is EventMonsterLit)
        {
            hasLit = true;
        }
    }


}

public class EventLightRequiredZoneEntered : Event { }

public class EventLightRequiredZoneFailed : Event { }