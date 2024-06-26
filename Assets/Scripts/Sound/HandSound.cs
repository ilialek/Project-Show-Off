using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSound : MonoBehaviour
{
    [SerializeField]
    private CustomXRDirectInteractor CustomXRDirectInteractor;
    // Start is called before the first frame update
    void Start()
    {
        CustomXRDirectInteractor = GetComponent<CustomXRDirectInteractor>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
