using FMOD.Studio;
using UnityEngine;

public class RadioSound : MonoBehaviour
{
    public EventInstance VO;
    public EventInstance VOStart;

    public VOTrigger VOTrigger;
    public bool isReset = true;

    void Start()
    {
        InitializeSound();
    }

    public void InitializeSound()
    {
        VO.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        VO.release();
        VOStart.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        VOStart.release();

        VO = AudioManager.instance.CreateInstance(FMODEvents.instance.VO);
        VOStart = AudioManager.instance.CreateInstance(FMODEvents.instance.VOStart);

        FMODUnity.RuntimeManager.AttachInstanceToGameObject(VO, GetComponent<Transform>(), GetComponent<Rigidbody>());
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(VOStart, GetComponent<Transform>(), GetComponent<Rigidbody>());


        VO.start(); VO.release();
        VOStart.start(); VOStart.release();
        VOTrigger.radioCount = 0;

        isReset = true;
    }

    void Update()
    {
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(VO, GetComponent<Transform>(), GetComponent<Rigidbody>());
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(VOStart, GetComponent<Transform>(), GetComponent<Rigidbody>());

        FMOD.Studio.PLAYBACK_STATE PbState;
        VO.getPlaybackState(out PbState);
        if (PbState == FMOD.Studio.PLAYBACK_STATE.SUSTAINING)
        {
            // Debug.Log("voice is currently paused");
        }

        int count = VOTrigger.radioCount;

        // Stop VOStart if count is greater than 0
        if (count > 0 && isReset)
        {
            VOStart.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            isReset = false;
            //Debug.Log("VOStart stopped because count > 0");
        }

        // Reset logic
        if (count == 6 || !isReset)
        {
            VOStart.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            //Debug.Log("Reset triggered: VO and VOStart stopped, radioCount reset.");
        }
    }
}


