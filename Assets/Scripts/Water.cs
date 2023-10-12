using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private Rigidbody rb;

    private float fire_speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.velocity = transform.up * fire_speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //known bug: TODO: water can take out lava
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Fire>())
        {
            //TODO: create steam
            //TODO: play sizzle sound
            Destroy(other.gameObject);
        }
        else if (other.GetComponent<Player>() == null)
        {
            Destroy(gameObject);
        }    
    }
}
