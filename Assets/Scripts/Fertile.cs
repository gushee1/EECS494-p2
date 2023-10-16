using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fertile : MonoBehaviour
{
    public GameObject bush;

    private bool has_bush;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] bushes = Physics.OverlapBox(
            GetComponent<Collider>().bounds.center,
            GetComponent<Collider>().bounds.extents,
            Quaternion.identity
        );

        has_bush = false;

        foreach (Collider c in bushes)
        {
            if(c.gameObject.GetComponent<Bush>() != null)
            {
                has_bush = true;
            }
        }

        if ( !has_bush )
        {
            Debug.Log("doing this now");
            Instantiate(bush, transform.position, Quaternion.identity);
        }
    }
}
