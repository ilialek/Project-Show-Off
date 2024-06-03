using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeOfDoomAndDestruction : MonoBehaviour, IEventListener
{
    void Start()
    {
        EventBus.Instance.Register(this);
        RideTimer.Instance.AddThreshold(5);
    }

    public void OnEvent(Event e)
    {
        if (e is EventLanternGoneOut)
        {
            DoDoomAndDeathAndStuff();
        }
        if (e is EventTimerThresholdReached)
        {
            DoDoomAndDeathAndStuff();
        }
    }

    void DoDoomAndDeathAndStuff()
    {
        Debug.Log("Doom and destruction!");
        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
    }

    void UndoDoom()
    {
        Debug.Log("Undoing doom (or undooming for short)");
        transform.position = new Vector3(transform.position.x, 2f, transform.position.z);
    }


}
