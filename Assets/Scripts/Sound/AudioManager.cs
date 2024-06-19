using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
    [Header("Volume")]
    [Range(0, 1)]
    public float masterVolume = 1;
    [Range(0, 1)]
    public float CartSFXVolume = 1;
    [Range(0, 1)]
    public float ambienceVolume = 1;
    [Range(0, 1)]
    public float SFXVolume = 1;

    private Bus masterBus;
    private Bus CartSFXBus;
    private Bus ambienceBus;
    private Bus sfxBus;

    private List<EventInstance> eventInstances;
    private List<StudioEventEmitter> eventEmitters;


    public static AudioManager instance { get; private set; }

    private EventInstance ambienceEventInstance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.LogError("Found more than one Audio Manager in the scene.");
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        eventInstances = new List<EventInstance>();
        eventEmitters = new List<StudioEventEmitter>();

        masterBus = RuntimeManager.GetBus("bus:/");
        CartSFXBus = RuntimeManager.GetBus("bus:/CartSFX");
        ambienceBus = RuntimeManager.GetBus("bus:/Ambience");
        sfxBus = RuntimeManager.GetBus("bus:/SFX");
    }

    private void Start()
    {
        InitializeAmbience(FMODEvents.instance.Ambience1);
    }

    private void Update()
    {
        masterBus.setVolume(masterVolume);
        CartSFXBus.setVolume(CartSFXVolume);
        ambienceBus.setVolume(ambienceVolume);
        sfxBus.setVolume(SFXVolume);

        //List<FMOD.Channel> activeChannels = GetAllActiveChannels();
    }


    /*
    public List<FMOD.Channel> GetAllActiveChannels()
    {
        List<FMOD.Channel> playingChannels = new List<FMOD.Channel>();

        FMOD.System coreSystem = RuntimeManager.CoreSystem;
        if (coreSystem == null)
        {
            Debug.LogError("FMOD CoreSystem is not valid.");
            return playingChannels;
        }

        int numChannels;
        FMOD.RESULT result = coreSystem.getChannelsPlaying(out numChannels);

        if (result == FMOD.RESULT.OK)
        {
            for (int i = 0; i < numChannels; i++)
            {
                FMOD.Channel channel;
                result = coreSystem.getChannel(i, out channel);
                if (result == FMOD.RESULT.OK && channel.hasHandle())
                {
                    bool isPlaying;
                    result = channel.isPlaying(out isPlaying);
                    if (result == FMOD.RESULT.OK && isPlaying)
                    {
                        playingChannels.Add(channel);
                    }
                }
            }
        }
        else
        {
            Debug.LogError($"FMOD error getting number of playing channels: {result}");
        }

        return playingChannels;
    }
    */

    private void InitializeAmbience(EventReference ambienceEventReference)
    {
        ambienceEventInstance = CreateInstance(ambienceEventReference);
        ambienceEventInstance.start();
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }

    public StudioEventEmitter InitializeEventEmitter(EventReference eventReference, GameObject emitterGameObject)
    {
        StudioEventEmitter emitter = emitterGameObject.GetComponent<StudioEventEmitter>();
        emitter.EventReference = eventReference;
        eventEmitters.Add(emitter);
        return emitter;
    }

    private void CleanUp()
    {
        foreach (EventInstance eventInstance in eventInstances)
        {
            eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            eventInstance.release();
        }

        foreach (StudioEventEmitter emitter in eventEmitters)
        {
            emitter.Stop();
        }
    }

    public EventInstance CreateInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        return eventInstance;
    }

    public void SetAmbienceParameter(string parameterName, float parameterValue)
    {
        ambienceEventInstance.setParameterByName(parameterName, parameterValue);
    }

    public void SetInstanceParameter(EventInstance eventInstance, string parameterName, float parameterValue)
    {
        eventInstance.setParameterByName(parameterName, parameterValue);
    }

    public void SetEmitterParameter(StudioEventEmitter emitter, string parameterName, float parameterValue)
    {
        if (emitter != null)
        {
            emitter.EventInstance.setParameterByName(parameterName, parameterValue);
        }
    }

    private void OnDestroy()
    {
        CleanUp();
    }
}
