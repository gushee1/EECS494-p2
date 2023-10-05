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
        GameObject water_instance = Instantiate(water);

        //TODO: handle rotating water sprite based on player orientation
        //TODO: make more like a projectile

        switch (player.direction_facing)
        {
            case Player.Direction.left:
                water_instance.transform.position = new Vector3(transform.position.x - .5f, transform.position.y);
                water_instance.GetComponent<Rigidbody>().velocity = new Vector3(-3, 0, 0);
                break;
            case Player.Direction.right:
                water_instance.transform.position = new Vector3(transform.position.x + .5f, transform.position.y);
                water_instance.GetComponent<Rigidbody>().velocity = new Vector3(3, 0, 0);
                break;
            case Player.Direction.up:
                water_instance.transform.position = new Vector3(transform.position.x, transform.position.y + .5f);
                water_instance.GetComponent<Rigidbody>().velocity = new Vector3(0, 3, 0);
                break;
            case Player.Direction.down:
                water_instance.transform.position = new Vector3(transform.position.x, transform.position.y - .5f);
                water_instance.GetComponent<Rigidbody>().velocity = new Vector3(0, -3, 0);
                break;
            default:
                water_instance.transform.position = transform.position;
                break;
        }
    }
}
