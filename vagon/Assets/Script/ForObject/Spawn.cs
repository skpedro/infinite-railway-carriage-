using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> vagon;
    [SerializeField] private Transform playerPos;
    
    private PlayerController player;

    private int danger;
    private int startVan = 4;
    private int[] indexGoodWan = new int[] { 1,2,4,5 };

    private float spawnPos = 0;
    private float wanLenght=10.3f;
 
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        SpawnVan(Random.Range(1, 4));
        SpawnVan(Random.Range(1, 4));
        SpawnVan(Random.Range(5,11));
        for (int i = 1; i < 6; i++)
        {
            SpawnVan(Random.Range(1,4));
        }
    }

    void Update()
    {
        if (player.dead != true)
        {
            if (playerPos.position.x > spawnPos - (startVan * wanLenght))
            {
                SpawnVan(Random.Range(0, 11));
            }
        }    
    }

    private void SpawnVan(int index)
    {
        if (vagon[index].CompareTag("DangerRailwayCarriage"))
        {
            danger++;
        }
        if (vagon[index].CompareTag("GoodRailwayCarriage"))
        {
            danger = 0;
        }
        // обычный спавн 
        if (danger < 3)
        {
            Instantiate(vagon[index],transform.right * spawnPos, Quaternion.identity);
            spawnPos += wanLenght;
        }

        if (danger > 2)
        {   
            Instantiate(vagon[indexGoodWan[Random.Range(0,3)]], transform.right * spawnPos, Quaternion.identity);
            spawnPos += wanLenght;
            danger = 0;
        }
    }
}
