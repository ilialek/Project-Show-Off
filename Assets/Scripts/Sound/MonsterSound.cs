using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterSound : MonoBehaviour
{
    [SerializeField]
    private Monster Monster;

    private EventInstance IdleInstance;
    private EventInstance ScaredInstance;
    // Start is called before the first frame update
    void Start()
    {
        Monster = GetComponent<Monster>();



    }

    // Update is called once per frame
    void Update()
    {
        switch (Monster.currentState)
        {
            case MonsterState.Idle:
                Idle();
                break;

            case MonsterState.Highlighted:

                Highlighted();

                break;

            case MonsterState.FollowingPath:
                break;

            case MonsterState.MovingToPosition:
                break;

            case MonsterState.Crawling:

                Debug.Log("Crawling");
                break;

            case MonsterState.End:

                Debug.Log("End");
                break;
        }
    }

    void Idle()
    {
        if (!IdleInstance.isValid())
        {
            IdleInstance = AudioManager.instance.CreateInstance(FMODEvents.instance.MonsterIdle);
            FMODUnity.RuntimeManager.AttachInstanceToGameObject(IdleInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
            IdleInstance.start();
            IdleInstance.release();
            Debug.Log("Idle");
        }
    }

    void Highlighted()
    {
        if (!ScaredInstance.isValid())
        {
            IdleInstance.stop(STOP_MODE.ALLOWFADEOUT);
            ScaredInstance = AudioManager.instance.CreateInstance(FMODEvents.instance.MonsterScared);
            FMODUnity.RuntimeManager.AttachInstanceToGameObject(ScaredInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
            ScaredInstance.start();
            ScaredInstance.release();
            Debug.Log("Scared");
        }
    }
}
