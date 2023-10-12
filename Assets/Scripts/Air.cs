using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : MonoBehaviour
{
    private Collider air_collider;
    private SpriteRenderer air_sprite_renderer;
    private Rigidbody rb;

    public Sprite fire;

    private float fire_speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        air_collider = GetComponent<Collider>();
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
