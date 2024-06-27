using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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

    private bool isOverheated = false;
    private bool isCoroutineRunning = false;
    void Start()
    {
        transformToRotate.localRotation = Quaternion.Euler(0, minAngle, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GetTheRotationInDegrees(transformToRotate.localEulerAngles.y));

        ManageTheRotation();
        CalculateOverHeat();
    }
    private float newYRotation;

    void ManageTheRotation()
    {
        float testLeverValue = leverScript.m_Value;
        if (!isOverheated)
        {
            if (testLeverValue < 0.5f)
            {
                if (newYRotation < 0.5f)
                {
                    newYRotation = GetTheRotationInDegrees(transformToRotate.localEulerAngles.y) + heatingMultiplier * (testLeverValue - 0.3f) * Time.deltaTime;
                }
                else
                {
                    newYRotation = GetTheRotationInDegrees(transformToRotate.localEulerAngles.y) - coolDownMultiplier * Time.deltaTime;
                }
            }
            else
            {
                newYRotation = GetTheRotationInDegrees(transformToRotate.localEulerAngles.y) - coolDownMultiplier * Time.deltaTime;
                newYRotation = GetTheRotationInDegrees(transformToRotate.localEulerAngles.y) + heatingMultiplier * (testLeverValue - 0.5f) * Time.deltaTime;
            }
        }
        else
        {
            newYRotation = GetTheRotationInDegrees(transformToRotate.localEulerAngles.y) - coolDownMultiplier * 0.1f * Time.deltaTime;
        }

        newYRotation = Mathf.Clamp(newYRotation, minAngle, maxAngle);
        transformToRotate.localEulerAngles = new Vector3(0, newYRotation, 0);
    }


    void CalculateOverHeat()
    {
        float heatval = GetEngineTemperature();
        //Debug.Log(heatval);
        if (heatval == 90f && !isCoroutineRunning)
        {
            Debug.Log("overheat");
            isOverheated = true;
            isCoroutineRunning = true;
            AudioManager.instance.PlayOneShot(FMODEvents.instance.OverHeat, transform.position);
            StartCoroutine(EngineCoolDown());
        }
    }
    IEnumerator EngineCoolDown()
    {
        yield return new WaitForSeconds(5f);
        AudioManager.instance.PlayOneShot(FMODEvents.instance.CoolDown, transform.position);
        yield return new WaitForSeconds(5f);
        AudioManager.instance.PlayOneShot(FMODEvents.instance.CooledDown, transform.position);
        isOverheated = false;
        isCoroutineRunning = false;
    }

    public float GetEngineTemperature()
    {
        return newYRotation;
    }

    public bool GetOverheatState()
    {
        return isOverheated;
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