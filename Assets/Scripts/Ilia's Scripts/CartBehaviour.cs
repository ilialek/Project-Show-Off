using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class CartBehaviour : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private Vector3 cartStartPoint;
    [SerializeField] private Vector3 cartEndPoint;
    [SerializeField] private float force;
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private GameObject monster;
    [SerializeField] private Transform screamerTransform;

    private Restart Restart;
    private EngineTemperature EngineTemperature;

    private bool workonce = false;
    public float leverValue = 0;

    public bool isGameOver = false;
    public bool isPlayerWinning = false;
    private bool isMonsterAttached = false;

    public Vector3 CartStartPoint => cartStartPoint;
    public Vector3 CartEndPoint => cartEndPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        EngineTemperature = FindObjectOfType<EngineTemperature>();
        Restart = FindObjectOfType<Restart>();

        if (screamerTransform == null)
        {
            Debug.LogError("ScreamerTransform is not assigned.");
        }
        if (monster == null)
        {
            Debug.LogError("Monster is not assigned.");
        }
    }

    private IEnumerator WaitForMonster()
    {
        yield return new WaitForSeconds(16);
        OnGameOver();
    }

    private void Update()
    {

        Monster monsterComponent = monster.GetComponent<Monster>();
        if (transform.position.z > monster.transform.position.z && (monsterComponent.currentState == MonsterState.Idle || monsterComponent.currentState == MonsterState.End))
        {
            force = 0;
            Debug.Log("KUIRAVa");

            monster.GetComponent<Animator>().SetBool("ToScream", true);

            isGameOver = true;
            StartCoroutine(WaitForMonster());
        }

        if (transform.position.z > -496)
        {
            if (particleSystem != null)
            {
                if (!workonce)
                {
                    particleSystem.Play();
                    workonce = true;
                }
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
    private bool hasDeathSoundPlayed = false;
    void FixedUpdate()
    {
        float overheat = EngineTemperature.GetOverheatState() ? 0f : 1f;
        rb.AddForce(Vector3.forward * force * leverValue * overheat);
        //Debug.Log(rb.velocity.magnitude);
        if (isGameOver && rb.velocity.magnitude < 0.1f && !isMonsterAttached)
        {
            AttachMonster();
        }
        if (isGameOver && !hasDeathSoundPlayed)
        {
            AudioManager.instance.PlayOneShot(FMODEvents.instance.DeadSound, transform.position);
            hasDeathSoundPlayed = true;
        }
    }

    private void AttachMonster()
    {
        Debug.Log("Attaching monster...");
        monster.transform.SetParent(this.transform, true); // Keep world position

        // Preserve the current y coordinate
        //Vector3 newLocalPosition = screamerTransform.localPosition;
        //newLocalPosition.y = monster.transform.localPosition.y;

        monster.transform.localPosition = screamerTransform.localPosition;
        monster.transform.localRotation = screamerTransform.localRotation;
        isMonsterAttached = true;
        Debug.Log("Monster attached at position: " + monster.transform.localPosition);
    }

    public void OnGameOver()
    {
        force = 0;
        Restart.RestartLevel();
    }

    public void OnTheEnd()
    {
        force = 0;
        GetComponent<Rigidbody>().velocity = Vector3.forward * 0.2f;
        isPlayerWinning = true;
    }

    public void PlayBreakAnimation()
    {
        // Play the break animation
    }

    public Vector3 GetSpeed()
    {
        return rb.velocity;
    }
}
