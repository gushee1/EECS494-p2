using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthAbility : PlayerAbility
{
    public Sprite earth_sprite;
    public Sprite grassy_sprite;

    private Animator animator;
    private Rigidbody rb;
    private SpriteRenderer player_sprite;
    private AudioSource earth_audio;

    public AudioClip earth_shift;

    private Burnable burnable;

    private bool is_active = false;

    [SerializeField]
    private bool has_grass = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player_sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody>();
        burnable = GetComponent<Burnable>();
        earth_audio = GetComponent<AudioSource>();

        if(GetComponent<Level7>() != null)
        {
            SetGrassMan();
            Activate();
        }
    }

    // Update is called once per frame
    void Update()
    {
        burnable.enabled = is_active && has_grass;

        if (IsActive())
        {
            player_sprite.sprite = has_grass ? grassy_sprite : earth_sprite;
        }
    }

    public override void Activate()
    {
        earth_audio.PlayOneShot(earth_shift);

        if (!IsActive())
        {
            is_active = true;
            player_sprite.sprite = has_grass ? grassy_sprite : earth_sprite;
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

    public void SetGrassMan()
    {
        has_grass = true;
    }

    public IEnumerator DisableGrassMan()
    {
        yield return new WaitForSeconds(1.5f);
        has_grass = false;
        burnable.ResetFire();
    }
}
