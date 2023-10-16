using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public bool invincible = false;

    private Collider fire_collider;
    private AudioSource fire_audio;

    // Start is called before the first frame update
    void Start()
    {
        fire_collider = GetComponent<Collider>();
        fire_audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( fire_collider == null )
        {
            return;
        }

        Collider[] overlapping_colliders = Physics.OverlapBox(
            fire_collider.bounds.center,
            fire_collider.bounds.extents,
            Quaternion.identity
        );

        for (int i = 0; i < overlapping_colliders.Length; i++)
        {
            //Debug.Log(overlapping_colliders[i]);
            if (overlapping_colliders[i].GetComponent<Burnable>() != null)
            {
                //Debug.Log("above object is burnable");
                overlapping_colliders[i].GetComponent<Burnable>().CatchFire();
                //Destroy(overlapping_colliders[i].gameObject, 1f);
            }
            else if (overlapping_colliders[i].GetComponent<TorchTrigger>() != null)
            {
                overlapping_colliders[i].GetComponent<TorchTrigger>().ActivateTrigger();
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);
        if (other.GetComponent<Player>() != null)
        {
            EventBus.Publish(new PlayerDiedEvent(other.GetComponent<Player>().player_id));
        }
        else if(other.GetComponent<TorchTrigger>() != null)
        {
            other.GetComponent<TorchTrigger>().ActivateTrigger();
        }
    }

    //TODO: can probably get rid of this and just make the blue fire a trigger as well because i implemented death
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Player>() != null)
        {
            EventBus.Publish(new PlayerDiedEvent(collision.gameObject.GetComponent<Player>().player_id));
        }
    }
}
