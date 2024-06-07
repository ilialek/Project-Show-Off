using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.XR;

//Hand is used to help animate
public class Hand : MonoBehaviour
{

    [SerializeField]
    private LayerMask ropeLayer;

    [SerializeField]
    private LayerMask starterHandleLayer;

    [SerializeField]
    private Transform handPrefab;

    [SerializeField]
    private InputDeviceCharacteristics inputDeviceCharacteristics;

    [SerializeField]
    private Rigidbody cartRigidBody;

    [SerializeField]
    private float moveForce;

    [SerializeField]
    private LightBehaviour lightBehaviour;

    [SerializeField]
    private Transform playerParentTransform;

    private bool isSnappedToRope = false;
    public bool didPullTheRope = false;
    public float treshold;

    private enum ChangeState { Unchanged, Increasing, Decreasing }
    private ChangeState lastState;
    private float changeOccurredAtValue = 0;

    private Vector3 handPrefabInitialPosition;
    private Quaternion handPrefabInitialRotation;

    private SphereCollider sphereCollider;

    private InputDevice _targetDevice;

    private Vector3 grabPosition;
    private Vector3 currentPosition;

    private Vector3 initialPosition;                                                                                                              
    private Vector3 previousPosition;
    private Vector3 deviceSpeed;

    public float resetThreshold = 0.1f;

    private Transform ropeTransform;

    private float netForwardDistance = 0f;

    private float previousDistanceValue = 0;

    public string test;

    public float velocityThreshold = 0.1f;

    private void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        handPrefabInitialPosition = handPrefab.localPosition;
        handPrefabInitialRotation = handPrefab.localRotation;
        InitializeHand();

        lastState = ChangeState.Unchanged;
    }

    private void InitializeHand()
    {
        List<InputDevice> devices = new List<InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(inputDeviceCharacteristics, devices);

        if (devices.Count > 0)
        {
            _targetDevice = devices[0];
        }
    }


    // Update is called once per frame
    private void Update()
    {
        test = lastState.ToString();

        if (!_targetDevice.isValid)
        {
            InitializeHand();
        }
        else
        {
            UpdateHand();
        }
    }

    private void UpdateHand()
    {
        //This will get the value for our trigger from the target device and output a flaot into triggerValue
        /*if (_targetDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerValue))
        {
            if(triggerText != null)
            triggerText.text = "Trigger value:" + triggerValue;
        }*/

        //This will get the value for our grip from the target device and output a flaot into gripValue

        _targetDevice.TryGetFeatureValue(CommonUsages.deviceVelocity, out deviceSpeed);

        //Debug.lo

        if (_targetDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool gripValue))
        {
            

            if (gripValue)
            {
                if (!isSnappedToRope)
                {
                    IsGrabbingTheRope();
                }
                else if (isSnappedToRope)
                {
                    if (!didPullTheRope)
                    {
                        CalculateTheMoveDistance();
                    }
                    
                }

                
            }
            else
            {
                if (isSnappedToRope)
                {
                    handPrefab.parent = transform.parent;
                    handPrefab.localPosition = handPrefabInitialPosition;
                    handPrefab.localRotation = handPrefabInitialRotation;
                    didPullTheRope = false;
                    changeOccurredAtValue = 0;
                    isSnappedToRope = false;
                }
            }

        }

    }

    private void IsGrabbingTheStarterHandle()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, sphereCollider.radius, starterHandleLayer);

        if (colliders.Length > 0)
        {
            SetTheHandlePosition(colliders[0]);
        }
    }

    private void SetTheHandlePosition(Collider collider)
    {
        collider.transform.parent = handPrefab;
        collider.transform.localPosition = new Vector3(0, 0, 0);
    }

    /*private void CalculateTheMoveDistance()
    {
        Vector3 ropeDirection = ropeTransform.up;

        Vector3 controllerMovement = CalculateLocalPositionRelativeToParent(playerParentTransform, transform) - grabPosition;
        float distanceAlongRope = Vector3.Dot(controllerMovement, ropeDirection);

        //float distanceAlongRope = Vector3.Dot(deviceSpeed, ropeDirection);

        Debug.Log(distanceAlongRope);



        if (distanceAlongRope < 0)
        {

            if (distanceAlongRope > previousDistanceValue)
            {
                if (lastState == ChangeState.Decreasing || lastState == ChangeState.Unchanged)
                {
                    changeOccurredAtValue = previousDistanceValue; // Store the value where the increase started
                    //Debug.Log("Started increasing at: " + changeOccurredAtValue);

                    //Debug.Log(changeOccurredAtValue - distanceAlongRope);

                    if (changeOccurredAtValue - distanceAlongRope >= -treshold)
                    {
                        didPullTheRope = true;
                    }

                    //lastState = ChangeState.Increasing;

                }
                else
                {
                    lastState = ChangeState.Increasing;
                }
                //lastState = ChangeState.Increasing;
                //Debug.Log("The value is increasing.");
            }
            else if (distanceAlongRope < previousDistanceValue)
            {
                if (lastState == ChangeState.Increasing || lastState == ChangeState.Unchanged)
                {
                    changeOccurredAtValue = previousDistanceValue; // Store the value where the decrease started
                                                                   // Debug.Log("Started decreasing at: " + changeOccurredAtValue);
                }

                Vector3 force = ropeDirection * (previousDistanceValue - distanceAlongRope) * moveForce;
                cartRigidBody.AddForce(force, ForceMode.Force);

                lastState = ChangeState.Decreasing;
                //Debug.Log("The value is decreasing.");
            }
            else
            {
                lastState = ChangeState.Unchanged;
                Debug.Log("The value is unchanged.");
            }

            previousDistanceValue = distanceAlongRope;


        }


    }*/

    private void CalculateTheMoveDistance()
    {
        Vector3 ropeDirection = ropeTransform.up;

        Vector3 controllerMovement = CalculateLocalPositionRelativeToParent(playerParentTransform, transform) - grabPosition;
        //float velocityAlongRope = Vector3.Dot(controllerMovement, ropeDirection);

        float velocityAlongRope = -Vector3.Dot(deviceSpeed, ropeDirection);

        Debug.Log(velocityAlongRope);

        if (velocityAlongRope > 0)
        {
            // Calculate the force to apply
            Vector3 forceToAdd = ropeDirection * velocityAlongRope * moveForce;

            // Apply the force to the cart's rigidbody
            cartRigidBody.AddForce(forceToAdd, ForceMode.Force);
        }
        else if (velocityAlongRope < -velocityThreshold)
        {
            // Disable the function once velocityAlongRope > velocityThreshold
            didPullTheRope = true;
        }


    }


    private void IsGrabbingTheRope()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, sphereCollider.radius, ropeLayer);

        if (colliders.Length > 0)
        {
            SnapToTheRope(colliders[0]);
        }
        
    }



    private void SnapToTheRope(Collider collider)
    {
        /*if (!isSnappedToRope) // Only snap if not already snapped
        {
            grabPosition = transform.parent.position;

            ropeTransform = collider.transform;
            // Detach the handPrefab from its parent (the controller)
            handPrefab.parent = null;

            // Get the closest point on the rope collider to the hand position
            Vector3 closestPoint = collider.ClosestPoint(transform.position);
            handPrefab.position = closestPoint;

            // Set the flag to true when snapped to rope
            isSnappedToRope = true;
        }*/


        if (!isSnappedToRope) // Only snap if not already snapped
        {
            grabPosition = CalculateLocalPositionRelativeToParent(playerParentTransform, transform);

            initialPosition = transform.position;
            previousPosition = transform.position;
            //netForwardDistance = 0f;

            ropeTransform = collider.transform;
            /*// Detach the handPrefab from its parent (the controller)
            handPrefab.parent = null;

            // Get the closest point on the rope collider to the hand position
            Vector3 closestPoint = collider.ClosestPoint(transform.position);
            handPrefab.position = closestPoint;

            // Set the flag to true when snapped to rope*/
            isSnappedToRope = true;
        }

    }


    Vector3 CalculateLocalPositionRelativeToParent(Transform parent, Transform child)
    {
        // Step 1: Get the world position of the Camera offset
        Vector3 worldPosition = child.position;

        // Step 2: Convert the world position to the local position relative to PLAYER CART
        Vector3 localPosition = parent.InverseTransformPoint(worldPosition);

        return localPosition;
    }


}





















//SMOOTHER MOVEMENT



/*private Vector3 smoothedVelocity;
private float smoothingFactor = 0.1f;

private void CalculateTheMoveDistance()
{
    // Calculate the direction along the rope
    Vector3 ropeDirection = ropeTransform.up;

    // Calculate the velocity of the hand controller
    velocity = (transform.position - previousPosition) / Time.deltaTime;
    previousPosition = transform.position;

    // Smooth the velocity
    smoothedVelocity = Vector3.Lerp(smoothedVelocity, velocity, smoothingFactor);

    // Project the velocity onto the rope direction to get the component along the rope
    float distanceAlongRope = -Vector3.Dot(smoothedVelocity, ropeDirection);

    // Debug the velocity for monitoring
    Debug.Log(smoothedVelocity);

    // If there's movement along the rope, apply the force to the cart
    if (distanceAlongRope > 0)
    {
        // Calculate the force to apply
        Vector3 force = ropeDirection * distanceAlongRope * moveForce;

        // Apply the force to the cart
        cartRigidBody.AddForce(force, ForceMode.Acceleration);
    }
}

// Ensure this method is called in FixedUpdate for consistent physics calculations
void FixedUpdate()
{
    CalculateTheMoveDistance();
}*/