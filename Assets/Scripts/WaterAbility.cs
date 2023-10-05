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
        GameObject water_instance_1 = Instantiate(water);
        GameObject water_instance_2 = Instantiate(water);

        //TODO: handle rotating water sprite based on player orientation

        switch (player.direction_facing)
        {
            case Player.Direction.left:
                water_instance_1.transform.position = new Vector3(transform.position.x - 1, transform.position.y);
                water_instance_2.transform.position = new Vector3(transform.position.x - 2, transform.position.y);
                break;
            case Player.Direction.right:
                water_instance_1.transform.position = new Vector3(transform.position.x + 1, transform.position.y);
                water_instance_2.transform.position = new Vector3(transform.position.x + 2, transform.position.y);
                break;
            case Player.Direction.up:
                water_instance_1.transform.position = new Vector3(transform.position.x, transform.position.y + 1);
                water_instance_2.transform.position = new Vector3(transform.position.x, transform.position.y + 2);
                break;
            case Player.Direction.down:
                water_instance_1.transform.position = new Vector3(transform.position.x, transform.position.y - 1);
                water_instance_2.transform.position = new Vector3(transform.position.x, transform.position.y - 2);
                break;
            default:
                water_instance_1.transform.position = transform.position;
                water_instance_2.transform.position = transform.position;
                break;
        }
    }
}
