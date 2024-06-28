using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

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
    [Range(0, 1)]
    public float VOVolume = 1;

    private Bus masterBus;
    private Bus CartSFXBus;
    private Bus ambienceBus;
    private Bus sfxBus;
    private Bus VOBus;

    private List<EventInstance> eventInstances;
    private List<StudioEventEmitter> eventEmitters;

    private string sceneName;
    public bool useDebug;

    public static AudioManager instance { get; private set; }

    public EventInstance ambienceEventInstance;

    private GameObject playerCart;

    void Awake()
    {
        sceneName = SceneManager.GetActiveScene().name;

        if (instance != null)
        {
            if (useDebug)
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
        VOBus = RuntimeManager.GetBus("bus:/Voice");
    }


    private void Start()
    {
        CheckIfSceneChange();
        InitializeAmbience(FMODEvents.instance.Ambience1);
        InitializeAudio();

    }

    public void CheckIfSceneChange()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "V2" && eventInstances.Count > 0)
        {
            CleanUp();
            InitializeAudio();
        }

    }

    public void InitializeAudio()
    {
        playerCart = GameObject.Find("Cart");
        InitializeAmbience(FMODEvents.instance.Ambience1);
    }

    private void Update()
    {
        masterBus.setVolume(masterVolume);
        CartSFXBus.setVolume(CartSFXVolume);
        ambienceBus.setVolume(ambienceVolume);
        sfxBus.setVolume(SFXVolume);
        VOBus.setVolume(VOVolume);

        if (playerCart != null)
        {
            ambienceEventInstance.set3DAttributes(RuntimeUtils.To3DAttributes(transform, playerCart.GetComponent<Rigidbody>()));
        }
        else
        {
            Debug.LogWarning("PlayerCart GameObject not found or is null.");
            InitializeAudio();
        }
    }

    private void InitializeAmbience(EventReference ambienceEventReference)
    {
        ambienceEventInstance = CreateInstance(ambienceEventReference);
        ambienceEventInstance.start();
        ambienceEventInstance.release();
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

       eventInstances.Clear();
    }

    private void OnDestroy()
    {
        CleanUp();
    }

    public EventInstance CreateInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        if (eventInstance.isValid())
        {
            eventInstances.Add(eventInstance);
        }
        else
        {
            Debug.LogWarning("Failed to create a valid event instance.");
        }
        return eventInstance;
    }

    public void SetAmbienceParameter(string parameterName, float parameterValue)
    {
        ambienceEventInstance.setParameterByName(parameterName, parameterValue);
    }

    public void SetInstanceParameter(EventInstance eventInstance, string parameterName, float parameterValue)
    {
        if (eventInstance.isValid())
        {
            eventInstance.setParameterByName(parameterName, parameterValue);
        }
        else
        {
            Debug.LogWarning("Attempted to set a parameter on an invalid event instance.");
        }
    }

    public void SetEmitterParameter(StudioEventEmitter emitter, string parameterName, float parameterValue)
    {
        if (emitter != null)
        {
            emitter.EventInstance.setParameterByName(parameterName, parameterValue);
        }
        else
        {
            Debug.LogWarning("Attempted to set a parameter on a null emitter.");
        }
    }

    public static void PlayOneShotWithParameters(EventReference eventReference, Vector3 position, params (string, float)[] parameters)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        eventInstance.set3DAttributes(RuntimeUtils.To3DAttributes(position));

        foreach (var parameter in parameters)
        {
            eventInstance.setParameterByName(parameter.Item1, parameter.Item2);
        }

        eventInstance.start();
        eventInstance.release();
    }

    public static void Nullify()
    {
        instance = null;
    }
}
