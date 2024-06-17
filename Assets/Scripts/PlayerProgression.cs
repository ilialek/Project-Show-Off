using UnityEngine;
using FMODUnity;

public class PlayerProgression : MonoBehaviour
{
    [SerializeField]
    public Transform startPoint;

    [SerializeField]
    public Transform endPoint;

    private float totalDistance;

    

    void Start()
    {
        totalDistance = Vector3.Distance(startPoint.position, endPoint.position);
    }

    void Update()
    {
       float progression = GetProgression();
       AudioManager.instance.SetAmbienceParameter("Progression", progression);



    }

    public float GetProgression()
    {
        // Calculate the player's current distance from the starting point
        float playerDistance = Vector3.Distance(transform.position, startPoint.position);

        // Calculate the progression as a value between 0 and 100
        float progression = Mathf.Clamp(playerDistance / totalDistance * 100, 0, 100);
        return progression;
    }
}
