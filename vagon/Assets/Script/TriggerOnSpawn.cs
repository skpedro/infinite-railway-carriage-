using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOnSpawn : MonoBehaviour
{
    private SpawningVagon spawn;

    private void Start()
    {
        spawn = GameObject.Find("SpawnPoint").GetComponent<SpawningVagon>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spawn.SpawnVagon();
    }
}
