using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Burnable : MonoBehaviour
{
    public GameObject fire;

    private float sweep_radius = 1f;

    private bool caught_fire = false;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        //may want to use overlap box instead
        Collider[] nearby_fires = Physics.OverlapSphere(transform.position, sweep_radius);

        foreach (Collider fire in nearby_fires)
        {
            if(fire.gameObject.GetComponent<Fire>() != null)
            {
                if (!caught_fire)
                {
                    StartCoroutine(SpreadFire());
                    caught_fire = true;
                }
            }
        }
    }

    public void CatchFire()
    {
        Destroy(gameObject, 1.5f);
    }

    private IEnumerator SpreadFire()
    {
        yield return new WaitForSeconds(1f);

        Instantiate(fire, transform);
    }
}
