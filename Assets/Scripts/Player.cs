using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerAbility ability;
    private SpriteRenderer player_sprite;
    private Animator player_animator;

    public Sprite facing_down;
    public Sprite facing_up;
    public Sprite facing_side;

    private float player_speed = 2;
    private bool has_key = false;

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
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        UpdateVisuals();

        if (Input.GetKeyDown(KeyCode.X))
        {
            ability.Activate();
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            TogglePlayer();
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
            player_animator.SetBool("moving", true);
        }
        else
        {
            player_animator.SetBool("moving", false);
        }

        rb.velocity = new Vector3(horizontal_movement, vertical_movement) * player_speed;
    }

    void TogglePlayer()
    {

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
}
