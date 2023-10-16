using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public GameObject soil;

    private Rigidbody rb;
    private AudioSource water_audio;

    public AudioClip extinguish_flame;

    private float fire_speed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        water_audio = GetComponent<AudioSource>();

        if (rb != null)
        {
            rb.velocity = transform.up * fire_speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //deal with making soil
    }


    //known bug: TODO: water can take out lava
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Fire>())
        {
            //TODO: create steam
            //TODO: play sizzle sound
            if (!other.GetComponent<Fire>().invincible)
            {
                Destroy(other.gameObject);
                if(water_audio != null)
                {
                    water_audio.PlayOneShot(extinguish_flame);
                }
            }
        }
        else if (other.GetComponent<Player>() == null)
        {
            if (other.GetComponent<Bush>() != null)
            {
                //Debug.Log("water is hitting bush");
                //other.GetComponent<Bush>().GrowBushes();
            }
            Destroy(gameObject);
        }    
    }

    private bool UnderTree()
    {
        Collider[] trees = Physics.OverlapBox(
            gameObject.GetComponent<Collider>().bounds.center,
            gameObject.GetComponent<Collider>().bounds.extents,
            Quaternion.identity
        );

        foreach ( Collider t in trees )
        {
            if ( t.gameObject.GetComponent<Burnable>() != null )
            {
                return true;
            }
        }

        return false;
    }
}
