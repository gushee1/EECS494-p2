using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerAbility ability;
    private SpriteRenderer player_sprite;
    private Animator player_animator;
    private PlayerManager player_manager;
    private Collider player_collider;
    public Camera player_cam;

    public Sprite facing_down;
    public Sprite facing_up;
    public Sprite facing_side;
    public Sprite dead;

    public int player_id;

    Subscription<PlayerDiedEvent> player_died_subscription;

    private float player_speed = 3;
    private bool has_key = false;
    [SerializeField] private bool is_active = false;
    private bool just_activated = false;

    public enum Direction
    {
        left, right, up, down
    }

    public Direction direction_facing = Direction.down;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ability = GetComponent<PlayerAbility>();
        player_sprite = GetComponent<SpriteRenderer>();
        player_animator = GetComponent<Animator>();
        player_manager = GetComponentInParent<PlayerManager>();
        player_cam = GetComponentInChildren<Camera>();
        player_collider = GetComponent<Collider>();

        player_died_subscription = EventBus.Subscribe<PlayerDiedEvent>(_OnPlayerDied);

        player_cam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //This chunk accounts for switching within one frame
        if (just_activated)
        {
            is_active = true;
            just_activated = false;
            return;
        }

        if (is_active)
        {
            if(!(GetComponent<EarthAbility>() != null && GetComponent<EarthAbility>().IsActive()))
            {
                Move();

                UpdateVisuals();
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                ability.Activate();
            }

            //TODO: potential issue is that as soon as player is activated in captures keycode down

            if (Input.GetKeyDown(KeyCode.Z))
            {
                //Debug.Log(gameObject.name + " did this");
                player_manager.SwitchPlayer();
            }
        }
    }

    void Move()
    {
        float horizontal_movement = 0;
        float vertical_movement = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontal_movement = -1;
            direction_facing = Direction.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontal_movement = 1;
            direction_facing = Direction.right;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            vertical_movement = 1;
            direction_facing = Direction.up;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            vertical_movement = -1;
            direction_facing = Direction.down;
        }

        if (horizontal_movement != 0 || vertical_movement != 0)
        {
            //Debug.Log(new Vector3(horizontal_movement, vertical_movement));
            player_animator.enabled = true;
            player_animator.SetBool("moving", true);

            if (GetComponent<AirAbility>() != null)
            {
                GetComponent<AirAbility>().Deactivate();
            }
        }
        else
        {
            player_animator.SetBool("moving", false);
            player_animator.enabled = false;
        }

        rb.velocity = new Vector3(horizontal_movement, vertical_movement) * player_speed;
    }

    void UpdateVisuals()
    {
        //TODO: fix sprite orientation when not moving
        player_animator.SetInteger("direction", (int)direction_facing);
        //Debug.Log(direction_facing);
        switch (direction_facing)
        {
            case Direction.left:
                //Debug.Log("left sprite");
                player_sprite.sprite = facing_side;
                transform.localScale = new Vector3(-1, 1, 1);
                break;
            case Direction.right:
                //Debug.Log("right sprite");
                player_sprite.sprite = facing_side;
                transform.localScale = new Vector3(1, 1, 1);
                break;
            case Direction.up:
                //Debug.Log("up sprite");
                player_sprite.sprite = facing_up;
                break;
            case Direction.down:
                //Debug.Log("down sprite");
                player_sprite.sprite = facing_down;
                break;
            default:
                break;
        }
    }

    public void CollectKey()
    {
        has_key = true;
    }
    public bool HasKey()
    {
        return has_key;
    }

    public void ActivateSelf()
    {
        player_cam.enabled = true;
        just_activated = true;
        player_animator.enabled = true;
    }

    public void DeactivateSelf()
    {
        player_cam.enabled = false;
        player_animator.enabled = false;
        rb.velocity = Vector3.zero;
        is_active = false;
    }

    void _OnPlayerDied(PlayerDiedEvent e)
    {
        if(e.player_id == player_id)
        {
            StartCoroutine(Die());
        }
    }

    public IEnumerator Die()
    {
        is_active = false;
        rb.velocity = Vector3.zero;
        player_animator.SetBool("moving", false);
        player_animator.enabled = false;
        player_collider.enabled = false;
        player_sprite.sprite = dead;

        yield return new WaitForSeconds(1f);

        Debug.Log("huh");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
