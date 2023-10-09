using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchTrigger : MonoBehaviour
{
    public GameObject object_to_create;

    public SpriteRenderer activated_sprite;

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
        activated_sprite.enabled = true;
        object_to_create.SetActive(true);
    }
}
