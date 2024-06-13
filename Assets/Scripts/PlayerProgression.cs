using UnityEngine;
using FMODUnity;

public class PlayerProgression : MonoBehaviour
{
    [SerializeField]
    public Transform startPoint;

    [SerializeField]
    public Transform endPoint;

    private FMOD.Studio.EventInstance Ambiance;
    private float totalDistance;

    

    void Start()
    {
        // Calculate the total distance between the start and end points
        totalDistance = Vector3.Distance(startPoint.position, endPoint.position);

        Ambiance = RuntimeManager.CreateInstance("event:/Ambience_cave");

        if (Ambiance.isValid())
        {
            Debug.Log("FMOD Event created successfully.");

            // Set the initial 3D attributes of the sound
            Set3DAttributes();

            Ambiance.start();
            Debug.Log("FMOD Event started.");
        }
        else
        {
            Debug.LogError("Failed to create FMOD Event.");
        }
    }

    void Update()
    {
       float progression = GetProgression();


        // Update the FMOD parameter with the progression value
        Ambiance.setParameterByName("Progression", progression);

        // Update the 3D attributes of the sound
        Set3DAttributes();


    }

    void OnDestroy()
    {
        Ambiance.release();
    }

    private void Set3DAttributes()
    {
        // Set the 3D attributes of the FMOD event instance to match the player's position
        FMOD.ATTRIBUTES_3D attributes = RuntimeUtils.To3DAttributes(transform.position);
        Ambiance.set3DAttributes(attributes);
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
