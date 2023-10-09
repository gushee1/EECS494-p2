using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanTrigger : MonoBehaviour
{
    public GameObject object_to_destroy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateTrigger()
    {
        //TODO: play whoosh sound
        Destroy(object_to_destroy);
    }
}
