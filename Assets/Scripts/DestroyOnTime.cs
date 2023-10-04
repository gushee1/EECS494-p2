using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTime : MonoBehaviour
{
    public float destroy_time;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroy_time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
