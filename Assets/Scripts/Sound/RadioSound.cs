using FMOD.Studio;
using UnityEngine;

public class RadioSound : MonoBehaviour
{
    public EventInstance VO;

    void Start()
    {
        VO = AudioManager.instance.CreateInstance(FMODEvents.instance.VO);
        VO.start();
    }

    void Update()
    {
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(VO, GetComponent<Transform>(), GetComponent<Rigidbody>());

        FMOD.Studio.PLAYBACK_STATE PbState;
        VO.getPlaybackState(out PbState);
        if (PbState == FMOD.Studio.PLAYBACK_STATE.SUSTAINING) ;
            //Debug.Log("voice is currently paused");
    }
}


    /*
    private PlayerProgression playerProgression;
    private LeverSound LeverSound;
    private EventInstance VOStart;
    private EventInstance VOEnd;
    private GameObject RadioObject;

    private bool isStartPlaying = false;
    private bool isEndPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        playerProgression = FindObjectOfType<PlayerProgression>();
        LeverSound = FindObjectOfType<LeverSound>();
        RadioObject = GameObject.Find("Radio");
        VOStart = AudioManager.instance.CreateInstance(FMODEvents.instance.VOStart);
        VOStart.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(RadioObject.transform));

    }

    // Update is called once per frame
    void Update()
    {
        VOStart.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(RadioObject.transform));

        if (playerProgression.GetProgression() < 28 && !isStartPlaying && LeverSound.hasPlayerMoved)
        {
            VOStart.start();
            VOStart.release();
            isStartPlaying = true;

        }
        else if (playerProgression.GetProgression() >= 28 && !isEndPlaying)
        {
            if (!VOEnd.isValid())
            {
                VOEnd = AudioManager.instance.CreateInstance(FMODEvents.instance.VOEnd);
                
                VOEnd.start();
                VOEnd.release();
                isEndPlaying = true;
            }
        }

        if(VOEnd.isValid())
        {
            VOEnd.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(RadioObject.transform));
        }
    }
    }
    */

