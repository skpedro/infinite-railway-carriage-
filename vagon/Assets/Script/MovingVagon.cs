using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingVagon : MonoBehaviour
{
    public static float speed = 3;

    void Update()
    {
        transform.Translate(Vector3.left*Time.deltaTime*speed);
        Debug.Log(speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Border"))
        {
            Destroy(gameObject);        
        } 
    }

}
