using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAbility : PlayerAbility
{
    public GameObject water;

    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Activate()
    {
        Quaternion rotation = Quaternion.identity;
        Vector3 spawn_transform = player.transform.position;

        switch (player.direction_facing)
        {
            case Player.Direction.left:
                spawn_transform = new Vector3(transform.position.x - .5f, transform.position.y);
                rotation = player.transform.rotation * Quaternion.Euler(0, 0, 90);
                break;
            case Player.Direction.right:
                spawn_transform = new Vector3(transform.position.x + .5f, transform.position.y);
                rotation = player.transform.rotation * Quaternion.Euler(0, 0, -90);
                break;
            case Player.Direction.up:
                spawn_transform = new Vector3(transform.position.x, transform.position.y + .5f);
                rotation = player.transform.rotation;
                break;
            case Player.Direction.down:
                spawn_transform = new Vector3(transform.position.x, transform.position.y - .5f);
                rotation = player.transform.rotation * Quaternion.Euler(0, 0, 180);
                break;
            default:
                break;
        }

        Instantiate(water, spawn_transform, rotation);
    }
}
