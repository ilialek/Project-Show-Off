using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    void Update()
    {
        if (UnityEngine.InputSystem.Keyboard.current.rKey.isPressed)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
