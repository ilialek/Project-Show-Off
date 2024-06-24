using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    [SerializeField] Transform snapPoint;


    void Start()
    {
        
    }


    void Update()
    {
        
    }

    void Collect()
    { 
        transform.parent = snapPoint;
        transform.position = Vector3.zero;

    }
}
