using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Conversational : MonoBehaviour
{
    public GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] nearby_objects = Physics.OverlapSphere(transform.position, 1f);

        foreach (Collider collider in nearby_objects)
        {
            if(collider.gameObject.GetComponent<Player>() != null)
            {
                text.SetActive(true);
                return;
            }
        }
        text.SetActive(false);
    }
}
