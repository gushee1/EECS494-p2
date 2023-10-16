using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanTrigger : MonoBehaviour
{
    public GameObject object_to_destroy;

    private AudioSource fan_audio;

    public AudioClip activated;

    private bool triggered = false;

    // Start is called before the first frame update
    void Start()
    {
        fan_audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateTrigger()
    {
        if (!triggered)
        {
            fan_audio.PlayOneShot(activated);
            Destroy(object_to_destroy);
            triggered = true;
        }
    }
}
