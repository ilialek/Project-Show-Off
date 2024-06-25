using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class RadioSound : MonoBehaviour
{
    private PlayerProgression playerProgression;
    private EventInstance VOStart;
    private EventInstance VOEnd;
    private GameObject RadioObject;

    private bool isStartPlaying = false;
    private bool isEndPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        playerProgression = FindObjectOfType<PlayerProgression>();
        RadioObject = GameObject.Find("Radio");
        VOStart = AudioManager.instance.CreateInstance(FMODEvents.instance.VOStart);
        VOStart.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(RadioObject.transform));
        VOStart.start();
        VOStart.release();  // Release the instance
    }

    // Update is called once per frame
    void Update()
    {
        VOStart.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(RadioObject.transform));

        if (playerProgression.GetProgression() < 28 && !isStartPlaying)
        {
            
            isStartPlaying = true;  // Mark as started

        }
        else if (playerProgression.GetProgression() >= 28 && !isEndPlaying)
        {
            if (!VOEnd.isValid())
            {
                VOEnd = AudioManager.instance.CreateInstance(FMODEvents.instance.VOEnd);
                
                VOEnd.start();
                VOEnd.release();  // Release the instance
                isEndPlaying = true;
            }
        }

        if(VOEnd.isValid())
        {
            VOEnd.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(RadioObject.transform));
        }
    }
}
