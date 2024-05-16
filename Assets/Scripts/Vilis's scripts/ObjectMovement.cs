using UnityEngine;
using UnityEngine.InputSystem; // Import the Input System namespace

public class ObjectMovement : MonoBehaviour
{
    public float speed = 5f; // Speed of movement, you can adjust this value in the Unity Editor

    // Declare a variable to hold the input action for forward movement
    private InputAction forwardInput;

    // Declare a variable to hold the input action for backward movement
    private InputAction backwardInput;

    void Start()
    {
        // Initialize the input actions for forward and backward movement
        forwardInput = new InputAction(binding: "<Keyboard>/w");
        forwardInput.Enable();

        backwardInput = new InputAction(binding: "<Keyboard>/s");
        backwardInput.Enable();
    }

    void Update()
    {
        // Get input from the forward movement action
        float forwardInputValue = forwardInput.ReadValue<float>();

        // Get input from the backward movement action
        float backwardInputValue = backwardInput.ReadValue<float>();

        // Calculate movement direction based on the input
        float verticalInput = forwardInputValue - backwardInputValue;

        // Calculate movement direction based on the input
        Vector3 movement = transform.forward * verticalInput * speed * Time.deltaTime;

        // Move the object based on the calculated movement
        transform.Translate(movement);
    }
}