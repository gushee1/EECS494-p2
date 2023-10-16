using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lake : MonoBehaviour
{
    public GameObject ice_path;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] overlapping_objects = Physics.OverlapBox(
            GetComponent<Collider>().bounds.center,
            GetComponent<Collider>().bounds.extents,
            Quaternion.identity
        );

        foreach ( Collider col in overlapping_objects)
        {
            if ( col.GetComponent<Air>() != null && col.GetComponent<Fire>() == null)
            {
                Instantiate(ice_path, transform.position, Quaternion.identity );
            }
        }
    }
}
