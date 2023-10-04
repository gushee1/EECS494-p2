using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    private float player_speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal_movement = 0;
        float vertical_movement = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontal_movement = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontal_movement = 1;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            vertical_movement = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            vertical_movement = -1;
        }

        if(horizontal_movement != 0 || vertical_movement != 0)
            Debug.Log(new Vector3(horizontal_movement, vertical_movement));

        rb.velocity = new Vector3 (horizontal_movement, vertical_movement) * player_speed;
    }
}
