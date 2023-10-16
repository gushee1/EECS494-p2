using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : MonoBehaviour
{
    private SpriteRenderer air_sprite_renderer;
    private Rigidbody rb;

    public Sprite fire;
    public Sprite ice;

    private float fire_speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        air_sprite_renderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody>();

        rb.velocity = transform.right * fire_speed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Fire>() != null)
        {
            gameObject.AddComponent<Fire>();
            air_sprite_renderer.sprite = fire;
        }
        else if(other.GetComponent<Water>() != null)
        {
            gameObject.AddComponent<Ice>();
            air_sprite_renderer.sprite = ice;
        }
        else if(other.GetComponent<FanTrigger>() != null)
        {
            other.GetComponent<FanTrigger>().ActivateTrigger();
        }
        else if(other.GetComponent<Wall>() != null)
        {
            Destroy(gameObject);
        }
    }
}
