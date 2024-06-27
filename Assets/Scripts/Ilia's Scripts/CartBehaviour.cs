using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using System.Runtime.CompilerServices;


public class CartBehaviour : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private Vector3 cartStartPoint;
    [SerializeField] private Vector3 cartEndPoint;

    [SerializeField] private float force;
    [SerializeField] private ParticleSystem particleSystem;

    [SerializeField]
    private GameObject monster;
    [SerializeField]
    private Transform screamerTransform;


    private EngineTemperature EngineTemperature;

    bool workonce = false;
    public float leverValue = 0;

    private bool isGameOver = false;

    public Vector3 CartStartPoint
    {
        get { return cartStartPoint; }
    }

    public Vector3 CartEndPoint
    {
        get { return cartEndPoint; }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        EngineTemperature = FindObjectOfType<EngineTemperature>();
    }

    private void Update()
    {

        if (transform.position.z > monster.transform.position.z && monster.GetComponent<Monster>().currentState == MonsterState.Idle)
        {
            

            monster.transform.parent = this.transform;
            monster.transform.localPosition = screamerTransform.localPosition;
            monster.transform.localRotation = screamerTransform.localRotation;

            monster.GetComponent<Animator>().SetBool("ToScream", true);
        }

        if (transform.position.z > -496)
        {
            if (particleSystem != null)
            {
                if (!workonce)
                    particleSystem.Play();
                workonce = true;
            }
            else
            {
                Debug.LogWarning("Particle System is not assigned.");
            }
        }

        if (UnityEngine.InputSystem.Keyboard.current.uKey.isPressed)
        {
            transform.Translate(Vector3.forward * 50 * Time.deltaTime);
        }
        if (UnityEngine.InputSystem.Keyboard.current.jKey.isPressed)
        {
            transform.Translate(Vector3.back * 50 * Time.deltaTime);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float overheat = EngineTemperature.GetOverheatState() ? 0f : 1f;
        rb.AddForce(Vector3.forward * force * leverValue * overheat);
    }

    public void OnGameOver()
    {
        force = 0;
        isGameOver = true;
    }

    public void OnTheEnd()
    {
        force = 0;
        GetComponent<Rigidbody>().velocity = Vector3.forward*.2f;
    }

    public void PlayBreakAnimation()
    {

    }

    public Vector3 GetSpeed()
    {
        return rb.velocity;
    }
}