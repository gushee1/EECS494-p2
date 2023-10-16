using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchTrigger : MonoBehaviour
{
    public GameObject object_to_create;

    public GameObject activated_state;

    private AudioSource torch_audio;

    public AudioClip activated;

    private bool triggered = false;

    // Start is called before the first frame update
    void Start()
    {
        torch_audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateTrigger()
    {
        if (!triggered)
        {
            torch_audio.PlayOneShot(activated);
            activated_state.SetActive(true);
            object_to_create.SetActive(true);
            triggered = true;
        }
        
    }
}
