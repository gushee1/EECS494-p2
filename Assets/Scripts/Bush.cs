using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour
{
    public GameObject new_bush;
    public GameObject soil;

    private Collider col;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Water>() != null)
        {
            GrowBushes();
        }
    }

    public void GrowBushes()
    {
        //Debug.Log("growing bushes");

        Vector3[] spawn_positions = new Vector3[] {
            new Vector3(col.bounds.center.x + 1, col.bounds.center.y),
            new Vector3(col.bounds.center.x - 1, col.bounds.center.y),
            new Vector3(col.bounds.center.x, col.bounds.center.y + 1),
            new Vector3(col.bounds.center.x, col.bounds.center.y - 1)
        };

        foreach ( Vector3 pos in spawn_positions )
        {
            Collider[] underlying_terrain = Physics.OverlapBox(
            pos,
            col.bounds.extents,
            Quaternion.identity);

            bool should_spawn = true;

            foreach ( Collider terrain_collider in underlying_terrain)
            {
                if (terrain_collider.GetComponent<Wall>() != null || terrain_collider.GetComponent<Player>() != null || terrain_collider.GetComponent<Lava>() != null)
                {
                    should_spawn = false;
                }
                if (terrain_collider.GetComponent<EarthAbility>() != null)
                {
                    if (terrain_collider.GetComponent<EarthAbility>().IsActive())
                    {
                        terrain_collider.GetComponent<EarthAbility>().SetGrassMan();
                    }
                }
                if (terrain_collider.GetComponent<Lake>() != null)
                {
                    should_spawn = true;
                    Instantiate(soil, pos, Quaternion.identity);
                    Destroy(terrain_collider.gameObject);
                }
            }

            if (should_spawn)
            {
                Instantiate(new_bush, pos, Quaternion.identity);
            }
        }
    }
}
