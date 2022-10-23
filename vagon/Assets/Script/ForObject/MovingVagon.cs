using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingVagon : MonoBehaviour
{
    public static float speed=3;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GoodRailwayCarriage")|| collision.gameObject.CompareTag("DangerRailwayCarriage"))
        {
            Destroy(collision.gameObject);
        }
    }
}
