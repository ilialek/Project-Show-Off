using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.XR.Content.Interaction;

public class CartSound : MonoBehaviour
{
    private float speed;
    private float rattle;

    [SerializeField] private EngineTemperature engineHeat;
    private PlayerProgression playerProgression;
    private StudioEventEmitter cartEmitter;
    private EventInstance engineHeatInstance;
    private EventInstance brakeInstance;
    private bool brakeOn = false;
    private float leverPosition;
    private XRLever XRLever;
    private CartBehaviour CartBehaviour;

    private GameObject playerCart;


    void Start()
    {
        InitializeComponents();
        InitializeAudioInstances();
    }

    void FixedUpdate()
    {

        cartEmitter.EventInstance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform, playerCart.GetComponent<Rigidbody>()));
        UpdateSoundLogic();

    }

    private void InitializeComponents()
    {
        cartEmitter = AudioManager.instance.InitializeEventEmitter(FMODEvents.instance.Cart, gameObject);
        playerProgression = FindObjectOfType<PlayerProgression>();
        XRLever = FindObjectOfType<XRLever>();
        CartBehaviour = FindObjectOfType<CartBehaviour>();

        playerCart = GameObject.Find("CART");
    }

    private void InitializeAudioInstances()
    {
        engineHeatInstance = AudioManager.instance.CreateInstance(FMODEvents.instance.EngineHeat);
        engineHeatInstance.start();
        engineHeatInstance.release();
        cartEmitter.Play();
        cartEmitter.EventInstance.release();
    }

    private void UpdateSoundLogic()
    {
        leverPosition = XRLever.GetLeverValue();
        Rigidbody cartRigidbody = CartBehaviour.GetComponent<Rigidbody>();
        speed = cartRigidbody.velocity.magnitude *0.3f;
        speed = Mathf.Clamp01(speed);
        //Debug.Log(speed);



        UpdateCartMovementSound();
        //UpdateEngineHeatSound();
    }

    private void UpdateBrakeSound()
    {
        if (!brakeInstance.isValid())
        {
            brakeInstance = AudioManager.instance.CreateInstance(FMODEvents.instance.Brake);
            brakeInstance.set3DAttributes(RuntimeUtils.To3DAttributes(transform, playerCart.GetComponent<Rigidbody>()));
        }
        else
        {
            brakeInstance.set3DAttributes(RuntimeUtils.To3DAttributes(transform, playerCart.GetComponent<Rigidbody>()));
        }
        if (leverPosition < 0.1f && !brakeOn && speed > 0.1f)
        {
            if (speed < 0.5f)
            {
                AudioManager.instance.SetInstanceParameter(brakeInstance, "BrakeStrenght", 0);
                //Debug.Log("Smallbrake");
            }
            else
            {
                AudioManager.instance.SetInstanceParameter(brakeInstance, "BrakeStrenght", 1);
                //Debug.Log("Bigbrake");
            }
            brakeInstance.start();
            brakeInstance.release();
            brakeOn = true;
            //Debug.Log("Played brake sound");
        }
        else if (leverPosition > 0.1f)
        {
            brakeOn = false;
            brakeInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            //Debug.Log("Brake is off");
        }
    }

    private void UpdateCartMovementSound()
    {
        float progression = playerProgression.GetProgression();
        float speedThreshold = 0.2f;
        float targetRattle = 0f;
        float waterfallFade = 1f;

        if (progression > 12 && progression < 17)
        {
            targetRattle = 1f;
        }
        else if (speed >= speedThreshold)
        {
            targetRattle = Mathf.Lerp(0f, 0.5f, (speed - speedThreshold) / (1f - speedThreshold));
        }

        rattle = Mathf.Lerp(rattle, targetRattle, Time.deltaTime * waterfallFade);
        if (Mathf.Abs(rattle) < 0.0001f) rattle = 0f;

        AudioManager.instance.SetEmitterParameter(cartEmitter, "Rattle", rattle);
        AudioManager.instance.SetEmitterParameter(cartEmitter, "Cart Speed", speed);

        if(speed > 0.2f)
        {
            UpdateBrakeSound();
        }
    }

    private void UpdateEngineHeatSound()
    {
        float tempAngle = engineHeat.GetEngineTemperature();
        float minValue = -90f;
        float maxValue = 90f;
        float normalizedValue = (tempAngle - minValue) / (maxValue - minValue);

        AudioManager.instance.SetInstanceParameter(engineHeatInstance, "EngineHeatVal", normalizedValue);
    }

    void OnDestroy()
    {
        cartEmitter.Stop();
        engineHeatInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }
}
