using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ProgressionTrigger
{
    public float threshold;
    public float deadzone;
    public bool oneShot;
    [System.NonSerialized]
    public bool triggered;
    public bool passed;
    public string name;

    // this assumes that the threshold is created in front of the cart. if not, set passed to true
    public ProgressionTrigger(float threshold, float deadzone, bool oneShot, bool passed = false, string name = "")
    {
        this.threshold = threshold;
        this.deadzone = Mathf.Max(deadzone, 0.01f);
        this.oneShot = oneShot;
        this.triggered = false;
        this.passed = passed;
        if (name == "")
            this.name = "Nameless Progression Trigger";
        else
            this.name = name;
    }
    public ProgressionTrigger(float threshold, float deadzone, bool oneShot, float currentDistance, string name = "")
    {
        this.threshold = threshold;
        this.deadzone = Mathf.Max(deadzone, 0.01f);
        this.oneShot = oneShot;
        this.triggered = false;
        this.passed = currentDistance > threshold;
        if (name == "")
            this.name = "Nameless Progression Trigger";
        else
            this.name = name;
    }

    public static bool operator ==(ProgressionTrigger t1, ProgressionTrigger t2)
    {
        return (
            t1.threshold == t2.threshold &&
            t1.deadzone == t2.deadzone &&
            t1.oneShot == t2.oneShot
        );
    }

    public static bool operator !=(ProgressionTrigger t1, ProgressionTrigger t2)
    {
        return (
            t1.threshold != t2.threshold ||
            t1.deadzone != t2.deadzone ||
            t1.oneShot != t2.oneShot
        );
    }

    public override bool Equals(object obj)
    {
        if (obj is ProgressionTrigger)
        {
            ProgressionTrigger other = (ProgressionTrigger)obj;
            return this == other;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
