using UnityEngine;

public class VOTrigger : MonoBehaviour
{

    public GameObject Radio;
    private RadioSound radioSound;

    public static int radioCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        radioSound = Radio.GetComponent<RadioSound>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cart")
        {
            radioSound.VO.keyOff();
            radioCount++;
            Debug.Log(radioCount);
        }
    }


}
