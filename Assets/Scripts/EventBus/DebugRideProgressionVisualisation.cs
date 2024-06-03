using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DebugRideProgressionVisualisation : MonoBehaviour
{
    public GameObject cubePrefab;
    private bool cubesVisible = true;

    private Keyboard keyboard;

    void Start()
    {
        StartCoroutine(DelayedInstantiateCubes());
        keyboard = Keyboard.current;
    }

    IEnumerator DelayedInstantiateCubes()
    {
        yield return new WaitForSeconds(0.2f);
        InstantiateCubes();
    }

    void Update()
    {
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            ToggleCubesVisibility();
        }
    }

    void InstantiateCubes()
    {
        foreach (ProgressionTrigger threshold in RideProgression.Instance.Thresholds)
        {
            GameObject cubeInstance = Instantiate(
                cubePrefab,
                RideProgression.Instance.rideStartPoint + 
                    (RideProgression.Instance.rideEndPoint - RideProgression.Instance.rideStartPoint).normalized * threshold.threshold,
                //new Vector3(10,10,50),
                Quaternion.identity
            );

            cubeInstance.transform.localScale = new Vector3(2f, 1f, threshold.deadzone * 2);
            //cubeInstance.transform.parent = transform;
            //cubeInstance.SetActive(cubesVisible);
        }
    }

    void ToggleCubesVisibility()
    {
        cubesVisible = !cubesVisible;
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(cubesVisible);
        }
    }
}
