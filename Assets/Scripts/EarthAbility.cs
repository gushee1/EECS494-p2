using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthAbility : PlayerAbility
{
    public Sprite earth_sprite;

    private Animator animator;
    private Rigidbody rb;
    private SpriteRenderer player_sprite;

    private bool is_active = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player_sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public override void Activate()
    {
        if (!IsActive())
        {
            is_active = true;
            player_sprite.sprite = earth_sprite;
            animator.enabled = false;
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
        }
        else
        {
            animator.enabled = true;
            is_active = false;
            rb.isKinematic = false;
        }
    }

    public bool IsActive()
    {
        return is_active;
    }
}
