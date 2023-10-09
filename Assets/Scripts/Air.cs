using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : MonoBehaviour
{
    private Collider air_collider;

    // Start is called before the first frame update
    void Start()
    {
        air_collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {

        Collider[] overlapping_colliders = Physics.OverlapBox(
            air_collider.bounds.center,
            air_collider.bounds.extents,
            Quaternion.identity
        );

        for (int i = 0; i < overlapping_colliders.Length; i++)
        {
            //Debug.Log(overlapping_colliders[i].gameObject.name);
            if (overlapping_colliders[i].GetComponent<FanTrigger>() != null)
            {
                //Debug.Log("hit da fan!>>>??");
                overlapping_colliders[i].GetComponent<FanTrigger>().ActivateTrigger();
            }
        }
    }
}
