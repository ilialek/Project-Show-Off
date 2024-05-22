using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightStarter : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;

    [SerializeField]
    private Light flashLight;

    [SerializeField]
    private float treshold;

    private Rigidbody rb;
    private Vector3 origin;

    private Vector3 previousPosition;
    public Vector3 Velocity { get; private set; }
    void Start()
    {
        origin = transform.position;

        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, origin);
        lineRenderer.SetPosition(1, transform.position);

    }

    public void BeingGrabbed(Vector3 handPosition)
    {
        transform.position = handPosition;

        Velocity = (transform.position - previousPosition) / Time.deltaTime;
        previousPosition = transform.position;

        Debug.Log(Velocity.magnitude);

        if (Velocity.magnitude >= treshold)
        {
            flashLight.enabled = true;
        }
    }

}
