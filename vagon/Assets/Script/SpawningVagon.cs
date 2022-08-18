using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningVagon : MonoBehaviour
{
    [SerializeField] private List<GameObject> vagon;
    [SerializeField] private Transform positionVagon;

    private int danger;
    private int rndIndex;
    private int[] indexGoodWan=new int[] {1};

    public void SpawnVagon()
    {
        rndIndex = Random.Range(0,2);
        if (vagon[rndIndex].CompareTag("DangerRailwayCarriage")){
            danger++;
            //Debug.Log("Danger:"+danger);
        }
        if (vagon[rndIndex].CompareTag("GoodRailwayCarriage")){
            danger = 0;
           // Debug.Log("Danger:" + danger);
        }

        if (danger<3){Instantiate(vagon[rndIndex], positionVagon.position, Quaternion.identity);}

        if (danger > 2)
        {
            // добавить вместо обычной 1 рандомный индекс безопасных вагонов
            Instantiate(vagon[1], positionVagon.position, Quaternion.identity);
            danger = 0;
        }
    }
}
