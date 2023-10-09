using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    private Collider path_collider;

    // Start is called before the first frame update
    void Start()
    {
        path_collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] overlapping_colliders = Physics.OverlapBox(
            path_collider.bounds.center,
            path_collider.bounds.extents,
            Quaternion.identity
        );

        for (int i = 0; i < overlapping_colliders.Length; i++)
        {
            if (overlapping_colliders[i].GetComponent<Lava>() != null)
            {
                Destroy(overlapping_colliders[i].gameObject);
            }
        }
    }
}
