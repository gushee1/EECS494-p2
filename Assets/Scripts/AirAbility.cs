using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AirAbility : PlayerAbility
{
    public GameObject air;
    public GameObject fire;

    private GameObject[] air_attack = new GameObject[5];

    private Player player;

    private bool is_active = false;

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
        if (!is_active)
        {
            bool is_fire_attack = false;
            RaycastHit hit;

            Ray ray;

            switch (player.direction_facing)
            {
                case Player.Direction.left:
                    ray = new Ray(player.gameObject.transform.position, Vector3.left);
                    break;
                case Player.Direction.right:
                    ray = new Ray(player.gameObject.transform.position, Vector3.right);
                    break;
                case Player.Direction.up:
                    ray = new Ray(player.gameObject.transform.position, Vector3.up);
                    break;
                case Player.Direction.down:
                    ray = new Ray(player.gameObject.transform.position, Vector3.down);
                    break;
                default:
                    ray = new Ray();
                    break;
            }

            if(Physics.Raycast(ray, out hit, 2f))
            {
                if(hit.transform.GetComponent<Fire>() != null)
                {
                    //Debug.Log("hit fire");
                    is_fire_attack = true;
                }
            }

            is_active = true;

            GameObject attack = is_fire_attack ? fire : air;

            GameObject air_1 = Instantiate(attack);
            GameObject air_2 = Instantiate(attack);
            GameObject air_3 = Instantiate(attack);
            GameObject air_4 = Instantiate(attack);
            GameObject air_5 = Instantiate(attack);

            air_attack[0] = air_1;
            air_attack[1] = air_2;
            air_attack[2] = air_3;
            air_attack[3] = air_4;
            air_attack[4] = air_5;
            air_attack[4] = air_5;


            switch (player.direction_facing)
            {
                case Player.Direction.left:
                    air_1.transform.position = new Vector3(transform.position.x - 1, transform.position.y);
                    air_2.transform.position = new Vector3(transform.position.x - 2, transform.position.y);
                    air_3.transform.position = new Vector3(transform.position.x - 3, transform.position.y);
                    air_4.transform.position = new Vector3(transform.position.x - 4, transform.position.y);
                    air_5.transform.position = new Vector3(transform.position.x - 5, transform.position.y);
                    break;
                case Player.Direction.right:
                    air_1.transform.position = new Vector3(transform.position.x + 1, transform.position.y);
                    air_2.transform.position = new Vector3(transform.position.x + 2, transform.position.y);
                    air_3.transform.position = new Vector3(transform.position.x + 3, transform.position.y);
                    air_4.transform.position = new Vector3(transform.position.x + 4, transform.position.y);
                    air_5.transform.position = new Vector3(transform.position.x + 5, transform.position.y);
                    break;
                case Player.Direction.up:
                    air_1.transform.position = new Vector3(transform.position.x, transform.position.y + 1);
                    air_2.transform.position = new Vector3(transform.position.x, transform.position.y + 2);
                    air_3.transform.position = new Vector3(transform.position.x, transform.position.y + 3);
                    air_4.transform.position = new Vector3(transform.position.x, transform.position.y + 4);
                    air_5.transform.position = new Vector3(transform.position.x, transform.position.y + 5);
                    break;
                case Player.Direction.down:
                    air_1.transform.position = new Vector3(transform.position.x, transform.position.y - 1);
                    air_2.transform.position = new Vector3(transform.position.x, transform.position.y - 2);
                    air_3.transform.position = new Vector3(transform.position.x, transform.position.y - 3);
                    air_4.transform.position = new Vector3(transform.position.x, transform.position.y - 4);
                    air_5.transform.position = new Vector3(transform.position.x, transform.position.y - 5);
                    break;
                default:
                    break;
            }
        }
        else
        {
            Deactivate();
        }
    }

    public void Deactivate()
    {
        is_active = false;
        for(int i = 0; i < air_attack.Length; i++)
        {
            Destroy(air_attack[i]);
        }
    }
}
