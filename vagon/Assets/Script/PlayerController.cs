using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int _additionalJump = 3;
   
    [SerializeField] private bool isPlane;
    [SerializeField] float jumpForse;
    [SerializeField] float checkRadius;

    [SerializeField] Transform planeCheck;
    [SerializeField] LayerMask whatIsPlane;

    // audio
    public AudioSource audio;
    [SerializeField] AudioClip clipJump;
     
    private GameManager gameManager;

    public bool dead=false;
    private Animator Anim;
    private Rigidbody2D rbPlayer;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        audio.volume = PlayerPrefs.GetFloat("Volume");
        Anim = GetComponent<Animator>();
        rbPlayer = GetComponent<Rigidbody2D>();
        gameManager._money.text = GameManager.money.ToString();
    }

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * MovingVagon.speed);
        isPlane = Physics2D.OverlapCircle(planeCheck.position,checkRadius,whatIsPlane);
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && _additionalJump>0)
        {    
            rbPlayer.AddForce(Vector2.up*jumpForse,ForceMode2D.Impulse);
            audio.PlayOneShot(clipJump);
            _additionalJump--;
        }
        if (isPlane==true){
            Anim.SetBool("IsRun", true);
            _additionalJump = 3;
        }
        else
        {
            Anim.SetBool("IsRun", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DangerRailwayCarriage"))
        {
            gameManager.particle.Play();
            Dead();
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("B_Money"))
        {
            GameManager.money = GameManager.money + 5;
            gameManager._money.text = GameManager.money.ToString();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("S_Money"))
        {
            GameManager.money = GameManager.money + 15;
            gameManager._money.text = GameManager.money.ToString();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("G_Money"))
        {
            GameManager.money = GameManager.money + 30;
            gameManager._money.text = GameManager.money.ToString();
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bridge"))
        {
            gameManager.particle.Play();
            Dead();
            Destroy(gameObject);
        }
    }

    public void Dead()
    {
        dead = true;
        gameManager.DeadScrin();
    }
}
