using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableOutline : MonoBehaviour
{
    [SerializeField] GameObject[] hands;
    [SerializeField] float distance = .2f;
    [SerializeField] GameObject[] outlined;

    void Start()
    {
    }

    void Update()
    {
        foreach (GameObject hand in hands)
        {
            if ((hand.transform.position - transform.position).magnitude <= distance)
            {
                ChangeLayer(10);
                break;
            }
            else
            {
                ChangeLayer(0);
            }
        }
    }

    private void ChangeLayer(int layer)
    {
        foreach (GameObject o in outlined)
        {
            o.layer = layer;
        }
    }
}
