using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocksFalling : MonoBehaviour, IEventListener
{
    [SerializeField] ProgressionTrigger trigger;

    [SerializeField] GameObject[] rocks;
    [SerializeField] Transform explosionPoint;

    public void OnEvent(Event e)
    {
        if (e is EventProgressionThresholdReached _e)
        {
            if (_e.threshold == trigger.threshold)
            {
                print("rocks falling");
                foreach (GameObject rock in rocks)
                {
                    rock.GetComponent<Rigidbody>().isKinematic = false;
                    rock.GetComponent<Rigidbody>().AddExplosionForce(2500, explosionPoint.position, 5);
                    AudioManager.instance.PlayOneShot(FMODEvents.instance.Rocks, transform.position);
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        EventBus.Instance.Register(this);
        RideProgression.Instance.AddThreshold(trigger);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
