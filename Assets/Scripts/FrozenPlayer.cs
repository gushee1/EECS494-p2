using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrozenPlayer : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<Player>().invincible = true;
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] overlapping_objects = Physics.OverlapBox(
           GetComponent<Collider>().bounds.center,
           GetComponent<Collider>().bounds.extents,
           Quaternion.identity
       );

        foreach (Collider col in overlapping_objects)
        {
            if (col.GetComponent<Fire>() != null)
            {
                StartCoroutine(Melt());
            }
        }
    }

    private IEnumerator Melt()
    {
        yield return new WaitForSeconds(1.5f);
        player.GetComponent<Player>().invincible = false;
        Destroy(gameObject);
    }
}
