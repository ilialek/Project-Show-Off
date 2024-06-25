using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Content.Interaction;
using UnityEngine.XR.Interaction.Toolkit;

public class Restart : MonoBehaviour
{
    private XRPushButton button;

    private void Start()
    {
        button = GetComponent<XRPushButton>();
        //button.onActivate.AddListener(ResetLevel);
        //button.activated.AddListener(ResetLevel);
        button.onValueChange.AddListener(MaybeResetLevel);
    }

    private void MaybeResetLevel(float arg0)
    {
        ResetLevel();
    }

    void Update()
    {

    }

    private void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
