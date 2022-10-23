using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuhcka : MonoBehaviour
{
    [SerializeField] private Transform point;
    [SerializeField] private GameObject tuchka;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tuchka"))
        {
            Instantiate(tuchka, new Vector3(point.transform.position.x, point.transform.position.y, 0), Quaternion.identity);
        }
    }
}
