using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBridge : MonoBehaviour
{
    [SerializeField] private GameObject bridge;
    [SerializeField] private Transform point;
    [SerializeField] private Transform playerPos;

    private PlayerController player;
    private float spawnPos = 0;
    private float bridgeLenght = 19f;
    private int startBridge = 2;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        for (int i = 1; i < startBridge; i++)
        {
            GeneratBridge();
        }
    }

    void Update()
    {
        if (player.dead != true)
        {
            if (playerPos.position.x > spawnPos - (startBridge * bridgeLenght))
            {
                GeneratBridge();
            }
        }
    }

    private void GeneratBridge()
    {
        Instantiate(bridge, new Vector3 (transform.position.x + spawnPos, -3.14f, 0), Quaternion.identity);
        spawnPos += bridgeLenght;
    }


   // private void OnCollisionEnter2D(Collision2D collision)
  //  {
        //if (collision.gameObject.CompareTag("Bridge"))
       // {
        //    Instantiate(bridge, new Vector3(point.transform.position.x, point.transform.position.y,0), Quaternion.identity);
       // }
   //}
}
