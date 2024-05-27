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
    private bool isGrabbingTheStarterHandle = false;

    private Vector3 handPrefabInitialPosition;
    private Quaternion handPrefabInitialRotation;

    private SphereCollider sphereCollider;

    private InputDevice _targetDevice;

    private Vector3 grabPosition;
    private Vector3 currentPosition;

    private Vector3 previousPosition;


    private Transform ropeTransform;

    private void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        handPrefabInitialPosition = handPrefab.localPosition;
        handPrefabInitialRotation = handPrefab.localRotation;
        InitializeHand();
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
                    CalculateTheMoveDistance();
                }

                
            }
            else
            {
                if (isSnappedToRope)
                {
                    handPrefab.parent = transform.parent;
                    handPrefab.localPosition = handPrefabInitialPosition;
                    handPrefab.localRotation = handPrefabInitialRotation;
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
        isGrabbingTheStarterHandle = true;
    }

    /*private void CalculateTheMoveDistance()
    {
        Vector3 ropeDirection = ropeTransform.up;

        Vector3 controllerMovement = transform.parent.position - grabPosition;

        // Project the movement vector onto the direction of the rope
        float distanceAlongRope = -Vector3.Dot(controllerMovement, ropeDirection);

        if (distanceAlongRope > 0)
        {

            Vector3 force = ropeDirection * distanceAlongRope * moveForce;

            // Apply the force to the platform's Rigidbody
            cartRigidBody.AddForce(force, ForceMode.Force);
        }

        *//*Vector3 force = ropeDirection * distanceAlongRope * moveForce;

        // Apply the force to the platform's Rigidbody
        cartRigidBody.AddForce(force, ForceMode.Force);*//*

    }*/


    private void CalculateTheMoveDistance()
    {
        Vector3 ropeDirection = ropeTransform.up;

        Vector3 controllerMovement = CalculateLocalPositionRelativeToParent(playerParentTransform, transform) - grabPosition;

        Debug.Log(controllerMovement);

        // Project the movement vector onto the direction of the rope
        float distanceAlongRope = -Vector3.Dot(controllerMovement, ropeDirection);

        if (distanceAlongRope > 0)
        {

            Vector3 force = ropeDirection * distanceAlongRope * moveForce;

            // Apply the force to the platform's Rigidbody
            cartRigidBody.AddForce(force, ForceMode.Force);
        }

        /*Vector3 force = ropeDirection * distanceAlongRope * moveForce;

        // Apply the force to the platform's Rigidbody
        cartRigidBody.AddForce(force, ForceMode.Force);*/

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
