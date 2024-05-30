using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RideProgression : MonoBehaviour
{
    public Vector3 rideStartPoint;
    public Vector3 rideEndPoint;

    private List<ProgressionTrigger> thresholds = new List<ProgressionTrigger>();
    private static RideProgression instance;

    private float totalDistance;
    private float currentDistance;

    CableCart cableCart;

    //private float maxDistance;
    public static RideProgression Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<RideProgression>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = "RideProgression";
                    instance = obj.AddComponent<RideProgression>();
                }
            }
            return instance;
        }
    }
    public List<ProgressionTrigger> Thresholds
    {
        get { return thresholds; }
    }

    void Start()
    {
        cableCart = FindObjectOfType<CableCart>();
        rideStartPoint = cableCart.cartStartPoint;
        rideEndPoint = cableCart.cartEndPoint;
        totalDistance = (rideEndPoint - rideStartPoint).magnitude;
    }

    public void AddThreshold(ProgressionTrigger threshold)
    {
        foreach (ProgressionTrigger t in thresholds)
        {
            if (threshold == t) return;
        }
        thresholds.Add(threshold);
    }

    void Update()
    {
        UpdateDistance();
    }

    void UpdateDistance()
    {
        // I assume the cart is moving in a stright line always
        currentDistance = (cableCart.transform.position - rideStartPoint).magnitude;

        for (int i = 0; i < thresholds.Count; i++)
        {
            ProgressionTrigger t = thresholds[i];

            if (t.oneShot && t.triggered) continue;
            if (currentDistance > t.threshold + t.deadzone ||
                currentDistance < t.threshold - t.deadzone)
            {
                t.triggered = false;
            }
            if (((!t.passed && currentDistance > t.threshold) ||
                (t.passed && currentDistance < t.threshold))
                )
            {
                t.passed = !t.passed;
                if (t.triggered)
                {
                    thresholds[i] = t;
                    continue;
                }
                EventBus.Instance.Emit(new EventProgressionThresholdReached(t.threshold));
                t.triggered = true;
            }

            thresholds[i] = t;
        }
    }

}

public class EventProgressionThresholdReached : Event
{
    public float threshold;
    public EventProgressionThresholdReached(float threshold)
    {
        this.threshold = threshold;
    }
}
