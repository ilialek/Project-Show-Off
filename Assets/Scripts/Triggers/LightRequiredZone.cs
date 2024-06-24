using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRequiredZone : MonoBehaviour, IEventListener
{
    [SerializeField] CartBehaviour cart;

    [SerializeField] ProgressionTrigger entry;
    [SerializeField] ProgressionTrigger exit;



    private bool hasLit = false;

    Collider monsterCollider;

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
        if (e is EventMonsterLit __e)
        {
            hasLit = true;
            this.monsterCollider = __e.monsterCollider;
            monsterCollider.GetComponent<Animator>().SetBool("on_light_detected", true);
        }
    }


}

public class EventLightRequiredZoneEntered : Event { }

public class EventLightRequiredZoneFailed : Event { }