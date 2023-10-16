using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private Collider door_collider;
    private AudioSource door_audio;

    public AudioClip door_locked;
    public AudioClip door_unlocked;

    public PlayerManager player_manager;

    // Start is called before the first frame update
    void Start()
    {
        door_collider = GetComponent<Collider>();
        door_audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Level_Select");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            if (collision.gameObject.GetComponent<Player>().HasKey())
            {
                door_audio.PlayOneShot(door_unlocked);
                door_collider.isTrigger = true;
            }
            else
            {
                door_audio.PlayOneShot(door_locked);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            player_manager.PlayerCompletedLevel();
        }
    }
}
