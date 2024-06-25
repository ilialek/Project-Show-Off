using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Content.Interaction;
using UnityEngine.XR.Interaction.Toolkit;

public class Restart : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private ActionBasedController[] controllers;
    [SerializeField] private float waitTime = 5f;
    private XRPushButton button;

    private bool creditsDisplayed = false;

    private void Start()
    {
        button = GetComponent<XRPushButton>();
        button.onValueChange.AddListener(RollCredits);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void RollCredits(float arg0)
    {
        canvas.gameObject.SetActive(true);
        creditsDisplayed = true;
        StartCoroutine(DelayedRestart());
    }

    private IEnumerator DelayedRestart()
    {
        yield return new WaitForSeconds(waitTime);
        RestartLevel();
    }

    private void Update()
    {
        if (creditsDisplayed)
        {
            if (controllers[0].selectActionValue.action.ReadValue<float>() > 0.5f ||
                controllers[1].selectActionValue.action.ReadValue<float>() > 0.5f)
            {
                RestartLevel();
            }
        }
    }
}
