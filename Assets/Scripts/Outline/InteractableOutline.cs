using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableOutline : MonoBehaviour
{
    [SerializeField] GameObject[] hands;
    [SerializeField] float distance = .2f;
    [SerializeField] GameObject[] outlined;
    [SerializeField] bool isRope = false;

    void Start()
    {
    }

    void Update()
    {
        foreach (GameObject hand in hands)
        {
            if ((hand.transform.position - transform.position).magnitude <= distance ||
                (isRope && (
                    new Vector2(hand.transform.position.x, hand.transform.position.y) - 
                    new Vector2(transform.position.x, transform.position.y
                    )).magnitude <= distance)
                )
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
