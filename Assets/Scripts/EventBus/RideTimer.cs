using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RideTimer : MonoBehaviour, IEventListener
{
    private static RideTimer instance;
    public static RideTimer Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<RideTimer>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = "RideTimer";
                    instance = obj.AddComponent<RideTimer>();
                }
            }
            return instance;
        }
    }

    void Start()
    {
        EventBus.Instance.Register(this);
        TimerStart(); // this should start on some event or something
    }   

    private ArrayList thresholds = new ArrayList();
    private float timeElapsed = 0.0f;
    private bool isRunning = false;

    void TimerStart()
    {
        timeElapsed = 0.0f;
        isRunning = true;
    }

    void TimerStop()
    {
        isRunning = false;
    }

    public void AddThreshold(float threshold)
    {
        if (thresholds.Contains(threshold)) return;
        thresholds.Add(threshold);
    }

    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer()
    {
        if (!isRunning) return;

        timeElapsed += Time.deltaTime;
        List<float> thresholdsToRemove = new List<float>();
        foreach (float threshold in thresholds)
        {
            if (timeElapsed >= threshold)
            {
                EventBus.Instance.Emit(new EventTimerThresholdReached(threshold));
                thresholdsToRemove.Add(threshold);
            }
        }

        foreach (float thresholdToRemove in thresholdsToRemove)
        {
            thresholds.Remove(thresholdToRemove);
        }
    }

    public void OnEvent(Event e)
    {
        //if (e is EventCableCartStarted)
        //{
        //    TimerStart();
        //    Debug.Log("Timer Started");
        //}
    }
}

public class EventTimerThresholdReached : Event
{
    public float threshold;
    public EventTimerThresholdReached(float threshold)
    {
        this.threshold = threshold;
    }
}
