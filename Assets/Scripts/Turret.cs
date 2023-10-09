using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject projectile;
    public Transform fire_position;

    private float fire_rate = 2f;

    private float time_since_last_fire = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time_since_last_fire += Time.deltaTime;
        if(time_since_last_fire >= fire_rate)
        {
            time_since_last_fire = 0;
            Instantiate(projectile, fire_position.position, fire_position.rotation);
        }
    }
}
