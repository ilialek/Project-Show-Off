using System.Collections;
using UnityEngine;
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
        if (button == null)
        {
            Debug.LogError("XRPushButton component not found on the GameObject.");
            return;
        }

        button.onValueChange.AddListener(RollCredits);
    }

    public void RestartLevel()
    {
        AudioManager.Nullify(); // Clean up AudioManager singleton
        FMODEvents.Nullify();
        Debug.Log("Restarting level...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //AudioManager.instance.InitializeAudio();
    }

    public void RollCredits(float arg0)
    {
        if (canvas == null)
        {
            Debug.LogError("Canvas is not assigned.");
            return;
        }

        canvas.gameObject.SetActive(true);
        creditsDisplayed = true;
        StartCoroutine(DelayedRestart());

        var endOverlay = canvas.GetComponent<EndOverlay>();
        if (endOverlay != null)
        {
            endOverlay.RollCredits();
        }
        else
        {
            Debug.LogError("EndOverlay component not found on the canvas.");
        }
    }

    private IEnumerator DelayedRestart()
    {
        yield return new WaitForSeconds(waitTime);
        RestartLevel();
    }

    private void Update()
    {
        if (creditsDisplayed && controllers != null && controllers.Length > 0)
        {
            foreach (var controller in controllers)
            {
                if (controller != null && controller.selectActionValue.action.ReadValue<float>() > 0.5f)
                {
                    RestartLevel();
                    break;
                }
            }
        }
    }

    private void OnDestroy()
    {
        if (button != null)
        {
            button.onValueChange.RemoveListener(RollCredits);
        }
    }
}
