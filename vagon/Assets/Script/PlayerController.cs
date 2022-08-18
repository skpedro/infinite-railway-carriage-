using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int additionalJump = 3;

    private bool isPlane; 

    [SerializeField] float jumpForse;
    [SerializeField] float checkRadius;
    [SerializeField] Transform planeCheck;
    [SerializeField] LayerMask whatIsPlane;

    private Rigidbody2D rbPlayer;

    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isPlane = Physics2D.OverlapCircle(planeCheck.position,checkRadius,whatIsPlane);
        if (Input.GetKeyDown(KeyCode.Space) && additionalJump>0)
        {
            rbPlayer.AddForce(Vector2.up*jumpForse,ForceMode2D.Impulse);
            additionalJump--;
        }
        if (isPlane==true){
            additionalJump = 3;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DangerRailwayCarriage"))
        {
            Destroy(gameObject);
            Debug.Log("you died");
        }
    }
}
