using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class EngineTemperature : MonoBehaviour
{
    [SerializeField]
    private XRLever leverScript;

    /*[SerializeField]
    [Range(0f, 1f)]
    float testLeverValue = 0f;*/

    [SerializeField]
    [Range(-90.0f, 90.0f)]
    float maxAngle = 90.0f;

    [SerializeField]
    [Range(-90.0f, 90.0f)]
    float minAngle = -90.0f;

    [SerializeField]
    private Transform transformToRotate;

    [SerializeField]
    private float currentTemperature = 0;

    [SerializeField]
    private float heatingMultiplier;

    [SerializeField]
    private float coolDownMultiplier;
    void Start()
    {
        transformToRotate.localRotation = Quaternion.Euler(0, minAngle, 0); 
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GetTheRotationInDegrees(transformToRotate.localEulerAngles.y));

        ManageTheRotation();
    }
    private float newYRotation;

    void ManageTheRotation()
    {
        float testLeverValue = leverScript.m_Value;

        if (testLeverValue < 0.5f)
        {
            // Cool down the engine temperature
            newYRotation = GetTheRotationInDegrees(transformToRotate.localEulerAngles.y) - coolDownMultiplier * Time.deltaTime;
        }
        else
        {
            // Heat up the engine temperature
            newYRotation = GetTheRotationInDegrees(transformToRotate.localEulerAngles.y) + heatingMultiplier * (testLeverValue - 0.5f) * Time.deltaTime;
        }

        newYRotation = Mathf.Clamp(newYRotation, minAngle, maxAngle);
        transformToRotate.localEulerAngles = new Vector3(0, newYRotation, 0);
    }

    public float GetEngineTemperature()
    {
        return newYRotation;
    }


    private float GetTheRotationInDegrees(float _rotation)
    {
        float rotation = _rotation;

        // Correct for crossing the 360-degree boundary
        if (_rotation > 180f)
        {
            rotation -= 360f;
        }
        else if (_rotation < -180f)
        {
            rotation += 360f;
        }

        return rotation;
    }
}
