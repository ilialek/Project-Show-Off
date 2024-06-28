using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CustomXRDirectInteractor : MonoBehaviour
{
    [SerializeField]
    private LayerMask ropeLayer;

    [SerializeField]
    private InputDeviceCharacteristics inputDeviceCharacteristics;

    [SerializeField]
    private float pullingForce;

    [SerializeField]
    private Rigidbody rigidBodyToPull;

    private SphereCollider sphereCollider;

    private InputDevice _targetDevice;

    private Vector3 deviceSpeed;
    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
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
        _targetDevice.TryGetFeatureValue(CommonUsages.deviceVelocity, out deviceSpeed);

        if (_targetDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool gripValue))
        {
            if (gripValue)
            {
                IsTheHandWithinTheRope();
            }
            else
            {
                
            }

        }

    }

    private void IsTheHandWithinTheRope()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, sphereCollider.radius, ropeLayer);

        if (colliders.Length > 0)
        {
            ExecuteThePullingLogic(colliders[0]);
        }

    }

    private void ExecuteThePullingLogic(Collider collider)
    {
        Vector3 ropeDirection = collider.transform.up;
        float deviceVelocityAlongRope = -Vector3.Dot(deviceSpeed, ropeDirection);
        Vector3 forceToAdd = ropeDirection * deviceVelocityAlongRope * pullingForce;
        AudioManager.instance.PlayOneShot(FMODEvents.instance.Hand, transform.position);
        rigidBodyToPull.AddForce(forceToAdd, ForceMode.Force);
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


}
