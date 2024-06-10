using UnityEngine;

public class FloatTracker : MonoBehaviour
{
    public float trackedValue; // The value you want to track
    private float previousValue;
    private float changeOccurredAtValue;
    private enum ChangeState { Unchanged, Increasing, Decreasing }
    private ChangeState lastState;

    void Start()
    {
        // Initialize the previous value and state
        previousValue = trackedValue;
        changeOccurredAtValue = trackedValue; // Initial value for the change point
        lastState = ChangeState.Unchanged;
    }

    void Update()
    {
        // Check if the value is increasing or decreasing
        if (trackedValue > previousValue)
        {
            if (lastState == ChangeState.Decreasing || lastState == ChangeState.Unchanged)
            {
                changeOccurredAtValue = previousValue; // Store the value where the increase started
                Debug.Log("Started increasing at: " + changeOccurredAtValue);
            }
            lastState = ChangeState.Increasing;
            Debug.Log("The value is increasing.");
        }
        else if (trackedValue < previousValue)
        {
            if (lastState == ChangeState.Increasing || lastState == ChangeState.Unchanged)
            {
                changeOccurredAtValue = previousValue; // Store the value where the decrease started
                Debug.Log("Started decreasing at: " + changeOccurredAtValue);
            }
            lastState = ChangeState.Decreasing;
            Debug.Log("The value is decreasing.");
        }
        else
        {
            lastState = ChangeState.Unchanged;
            Debug.Log("The value is unchanged.");
        }

        // Update the previous value for the next frame
        previousValue = trackedValue;
    }

    public void SetTrackedValue(float newValue)
    {
        trackedValue = newValue;
    }
}