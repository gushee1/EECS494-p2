using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private Collider fire_collider;

    // Start is called before the first frame update
    void Start()
    {
        fire_collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] overlapping_colliders = Physics.OverlapBox(
            fire_collider.bounds.center,
            fire_collider.bounds.extents,
            Quaternion.identity
        );

        for (int i = 0; i < overlapping_colliders.Length; i++)
        {
            //Debug.Log(overlapping_colliders[i]);
            if (overlapping_colliders[i].GetComponent<Burnable>() != null)
            {
                //Debug.Log("above object is burnable");
                Destroy(overlapping_colliders[i].gameObject, 1f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);
        if (other.GetComponent<Player>() != null)
        {
            //TODO: reset scene
        }
    }
}
