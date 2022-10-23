using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Following : MonoBehaviour
{
    private PlayerController player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        
    }
    void Update()
    {
        if (player.dead!=true)
        {
            transform.Translate(Vector3.right * Time.deltaTime * MovingVagon.speed);
        }
    }
}
