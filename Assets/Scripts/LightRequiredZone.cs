using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRequiredZone : MonoBehaviour, IEventListener
{
    [SerializeField] ProgressionTrigger entry;
    [SerializeField] ProgressionTrigger exit;

    private bool hasLit = false;

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
                }
            }
        }
        if (e is EventMonsterLit)
        {
            hasLit = true;
        }
    }

    void Start()
    {
        EventBus.Instance.Register(this);
        RideProgression.Instance.AddThreshold(entry);
        RideProgression.Instance.AddThreshold(exit);
    }
}

public class EventLightRequiredZoneEntered : Event { }