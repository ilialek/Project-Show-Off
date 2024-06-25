using UnityEngine;

public class VOTrigger : MonoBehaviour
{

    public GameObject Radio;
    private RadioSound radioSound;

    // Start is called before the first frame update
    void Start()
    {
        radioSound = Radio.GetComponent<RadioSound>();
    }
    void OnTriggerEnter()
    {
        radioSound.VO.keyOff();
        //Debug.Log("cue");
    }
}
