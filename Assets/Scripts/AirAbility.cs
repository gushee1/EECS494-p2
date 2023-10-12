using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AirAbility : PlayerAbility
{
    public GameObject air;
    public GameObject fire;

    private Player player;

    private bool is_active = false;
    private float fire_rate = .5f;
    private float time_since_last_fired;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (is_active)
        {
            Quaternion rotation = Quaternion.identity;
            Vector3 spawn_transform = player.transform.position;

            switch (player.direction_facing)
            {
                case Player.Direction.down:
                    rotation = player.transform.rotation * Quaternion.Euler(0, 0, -90);
                    spawn_transform = new Vector3(player.transform.position.x, player.transform.position.y - .5f);
                    break;
                case Player.Direction.up:
                    spawn_transform = new Vector3(player.transform.position.x, player.transform.position.y + .5f);
                    rotation = player.transform.rotation * Quaternion.Euler(0, 0, 90);
                    break;
                case Player.Direction.left:
                    rotation = player.transform.rotation * Quaternion.Euler(0, 0, 180);
                    spawn_transform = new Vector3(player.transform.position.x - .5f, player.transform.position.y);
                    break;
                case Player.Direction.right:
                    rotation = player.transform.rotation;
                    spawn_transform = new Vector3(player.transform.position.x + .5f, player.transform.position.y);
                    break;
                default:
                    break;
            }

            time_since_last_fired += Time.deltaTime;
            if(time_since_last_fired >= fire_rate)
            {
                time_since_last_fired = 0;
                Instantiate(air, spawn_transform, rotation);
            }
        }
    }

    public override void Activate()
    {
        is_active = true;
    }

    public void Deactivate()
    {
        is_active = false;
    }
}
