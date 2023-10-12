using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private Collider door_collider;

    public PlayerManager player_manager;

    // Start is called before the first frame update
    void Start()
    {
        door_collider = GetComponent<Collider>();
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
                door_collider.isTrigger = true;
            }
            else
            {
                //TODO: play locked sound
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
