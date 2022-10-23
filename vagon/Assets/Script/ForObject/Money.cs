using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private GameObject[] money;
    private PlayerController player;

    private int indexMoney;
    private float rndPosY;
    private int secondToSpawn;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (!player.dead)
        {
            indexMoney = Random.Range(0,3);
            rndPosY = Random.Range(8,18);
            secondToSpawn = Random.Range(5,20);
            yield return new WaitForSeconds(secondToSpawn);
            Instantiate(money[indexMoney],new Vector2(transform.position.x,rndPosY),Quaternion.identity);
        }
    }

}
