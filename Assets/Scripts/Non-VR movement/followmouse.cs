using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // Import the Input System namespace

public class followmouse : MonoBehaviour
{
    public float mouseX = 0f;
    public float mouseY = 0f;

    public float sensitivity = 0.1f;

    // Update is called once per frame
    void Update()
    {
        // Get mouse input using the new Input System
        Vector2 mouseDelta = Mouse.current.delta.ReadValue();

        mouseX += mouseDelta.y * -1 * sensitivity;
        mouseY += mouseDelta.x * sensitivity;
        transform.localEulerAngles = new Vector3(mouseX, mouseY, 0);
    }
}
