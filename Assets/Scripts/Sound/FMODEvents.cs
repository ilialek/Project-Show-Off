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
