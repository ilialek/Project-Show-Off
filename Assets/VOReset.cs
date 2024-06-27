using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VOReset : MonoBehaviour
{
    [SerializeField]
    private RadioSound RadioSound;

    private void Start()
    {
        RadioSound.GetComponent<RadioSound>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cart")
        {
            RadioSound.InitializeSound();
            //Debug.Log("reset");
        }
    }

}
