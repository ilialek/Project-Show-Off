
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CatSnapPoint : MonoBehaviour
//{
//    public float snapDuration = 0.5f;


//    private Vector3 initialPosition;
//    private Quaternion initialRotation;

//    public void SoftSnap(Cat cat)
//    {
//        initialPosition = cat.transform.position;
//        initialRotation = cat.transform.rotation;

//        cat.transform.parent = transform;

//        cat.GetComponent<Rigidbody>().velocity = Vector3.zero;
//        cat.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
//        cat.GetComponent<Rigidbody>().isKinematic = true;

//        StartCoroutine(SnapCoroutine(cat));
//    }

//    private IEnumerator SnapCoroutine(Cat cat)
//    {
//        float elapsedTime = 0f;
//        while (elapsedTime < snapDuration)
//        {
//            elapsedTime += Time.deltaTime;
//            float t = Mathf.Clamp01(elapsedTime / snapDuration);

//            cat.transform.localPosition = Vector3.Lerp(initialPosition, targetPosition, t);
//            cat.transform.localRotation = Quaternion.Slerp(initialRotation, targetRotation, t);

//            yield return null;
//        }

//    }
//}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSnapPoint : MonoBehaviour
{
    [SerializeField] private float snapDuration = 0.5f;

    public void SoftSnap(Cat cat)
    {
        cat.transform.parent = transform;
        cat.GetComponent<Rigidbody>().velocity = Vector3.zero;
        cat.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        cat.GetComponent<Rigidbody>().isKinematic = true;
        StartCoroutine(SnapCoroutine(cat)); 
    }

    private IEnumerator SnapCoroutine(Cat cat)
    {
        Vector3 initialPosition = cat.transform.position - transform.position;
        Quaternion initialRotation = cat.transform.rotation;

        float elapsedTime = 0f;
        while (elapsedTime < snapDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / snapDuration);

            cat.transform.localPosition = Vector3.Lerp(initialPosition, Vector3.zero, t);
            cat.transform.localRotation = Quaternion.Slerp(initialRotation, Quaternion.identity, t);

            yield return null;
        }
    }
}