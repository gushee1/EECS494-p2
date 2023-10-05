using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class FireAbility : PlayerAbility
{
    public GameObject fire;

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
        GameObject fire_instance = Instantiate(fire);

        switch (player.direction_facing)
        {
            case Player.Direction.left:
                fire_instance.transform.position = new Vector3(transform.position.x - 1, transform.position.y);
                break;
            case Player.Direction.right:
                fire_instance.transform.position = new Vector3(transform.position.x + 1, transform.position.y);
                break;
            case Player.Direction.up:
                fire_instance.transform.position = new Vector3(transform.position.x, transform.position.y + 1);
                break;
            case Player.Direction.down:
                fire_instance.transform.position = new Vector3(transform.position.x, transform.position.y - 1);
                break;
            default:
                fire_instance.transform.position = transform.position;
                break;
        }
    }
}
