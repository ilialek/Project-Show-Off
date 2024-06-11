using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Cave Ambience")]
    [field: SerializeField] public EventReference Ambience1 { get; private set; }
    [field: SerializeField] public EventReference Scary { get; private set; }


    [field: Header("SFX")]
    [field: SerializeField] public EventReference Test { get; private set; }
    [field: SerializeField] public EventReference Cart { get; private set; }
    [field: SerializeField] public EventReference Hand { get; private set; }
    [field: SerializeField] public EventReference LightOff { get; private set; }
    [field: SerializeField] public EventReference LightWarning { get; private set; }
    [field: SerializeField] public EventReference LightCharge { get; private set; }
    [field: SerializeField] public EventReference LightOn { get; private set; }
    [field: SerializeField] public EventReference WheelRotation { get; private set; }
    [field: SerializeField] public EventReference WheelFull { get; private set; }
    [field: SerializeField] public EventReference Backspin { get; private set; }
    public static FMODEvents instance {get; private set;}

  

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one FMOD Events instance in the scene");
        }
        instance = this;
    }
}
