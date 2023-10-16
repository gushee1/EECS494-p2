using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody rb;
    private SpriteRenderer arrow_sprite;

    public Sprite frozen;

    private float speed = 3f;

    private bool is_frozen = false;

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
        if(collision.gameObject.GetComponent<Player>() != null)
        {
            if (!(collision.gameObject.GetComponent<EarthAbility>() != null && collision.gameObject.GetComponent<EarthAbility>().IsActive()))
            {
                EventBus.Publish(new PlayerDiedEvent(collision.gameObject.GetComponent<Player>().player_id));
            }
            Destroy(gameObject);
        }
        else if (collision.gameObject.GetComponent<Bush>() != null)
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.GetComponent<Turret>() == null)
        {
            if (!is_frozen)
                Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Ice>() != null)
        {
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
            arrow_sprite.sprite = frozen;
            is_frozen = true;
        }
    }
}
