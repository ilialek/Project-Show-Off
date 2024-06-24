using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Cat : MonoBehaviour
{
    [SerializeField] CatSnapPoint snapPoint;
    XRGrabInteractable grabInteractable;


    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    void OnRelease(SelectExitEventArgs args)
    {
        // Code to execute once the object is released
        print("Cat has been released");
        snapPoint.SoftSnap(this);
    
    }
}
