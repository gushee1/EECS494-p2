using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody rb;
    private SpriteRenderer arrow_sprite;

    private float speed = 2f;

    //TODO: use eventbus for death events

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = -transform.up * speed;
        arrow_sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            if(collision.gameObject.GetComponent<EarthAbility>() != null && collision.gameObject.GetComponent<EarthAbility>().IsActive())
            {
                Destroy(gameObject);
            }
            else
            {
                StartCoroutine(collision.gameObject.GetComponent<Player>().Die());
                arrow_sprite.enabled = false;
            }
        }
        else if (collision.gameObject.GetComponent<Turret>() == null)
        {
            Destroy(gameObject);
        }
    }
}
