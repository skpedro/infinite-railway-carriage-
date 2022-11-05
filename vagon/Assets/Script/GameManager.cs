using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _stopMenu;
    [SerializeField] GameObject _stopButton;
    [SerializeField] GameObject _buttonRestart;
    [SerializeField] GameObject _buttonContinue;
    [SerializeField] GameObject _buttonRestInGame;
    [SerializeField] GameObject[] playerS;
    [SerializeField] Transform playerPos;
    [SerializeField] Slider sliderVolume;
    [SerializeField] GameObject hint;
    [SerializeField] TextMeshProUGUI textRecord;
    [SerializeField] TextMeshProUGUI Rast;
    private AudioSource music;

    public ParticleSystem particle;
    
    private PlayerController player;

    public TextMeshProUGUI _money;

    private bool gameOver = false;

    public static int money;
    public static int indexSckin;

    private float rast;
    private float records;
    private float permissibleSpeed = 10;
    private float firstWave = 2;
    private float secondWave = 2.5f;
    private float thirdWave = 3;
   
    private void Start()
    {
        records = PlayerPrefs.GetFloat("Records");
        textRecord.text = textRecord.text + records.ToString();
        Instantiate(playerS[PlayerPrefs.GetInt("Player")], new Vector3(playerPos.position.x, playerPos.position.y, playerPos.position.z) ,Quaternion.identity);
        StartCoroutine(IncreaseSpeed());
        StartCoroutine(DestroyImage());
        //Application.targetFrameRate = 200;  
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        money = PlayerPrefs.GetInt("Money");
        music = GetComponent<AudioSource>();
        music.volume = PlayerPrefs.GetFloat("Volume");
        sliderVolume.value = PlayerPrefs.GetFloat("Volume");
    }
    private void Update()
    {
        if (player.dead!=true)
        {
            rast += Time.deltaTime;
            Rast.text = "счет:" + rast;
        }
    }
    public static GameManager Instance;

    IEnumerator IncreaseSpeed()
    {   
            while (MovingVagon.speed < permissibleSpeed)
            {
                yield return new WaitForSeconds(2);
                MovingVagon.speed = MovingVagon.speed + 0.3f;
            }
            permissibleSpeed = 20;
            while (MovingVagon.speed < permissibleSpeed)
            {
                yield return new WaitForSeconds(2);
                MovingVagon.speed = MovingVagon.speed + 0.2f;
            }
            permissibleSpeed = 30;
            while (MovingVagon.speed < permissibleSpeed)
            {
                yield return new WaitForSeconds(3);
                MovingVagon.speed = MovingVagon.speed + 0.2f;
            }          
    }
    // buttons


    IEnumerator DestroyImage()
    {
        yield return new WaitForSeconds(3);
        Destroy(hint);
        StopCoroutine(DestroyImage());
    }

    
    IEnumerator Wait(float sekond)
    {   
        while (true)
        {
            Record();
            music.Stop();
            yield return new WaitForSeconds(sekond);
            _stopMenu.gameObject.SetActive(true);
           _buttonRestart.SetActive(true);
           _buttonContinue.SetActive(false);
            PlayerPrefs.SetInt("Money", money);
            //выключить звуки
        }
    }
    private void Record()
    {
        if (records<rast)
        {
            PlayerPrefs.SetFloat("Records",rast);
            rast = 0;
        }
    }
    public void Stop()
    {
        _stopMenu.SetActive(true);
        _stopButton.SetActive(false);
        _buttonRestInGame.SetActive(false);
        Time.timeScale = 0;
    }

    public void DeadScrin()
    {
        StartCoroutine(Wait(1f));
    }

    public void Сontinue()
    {
        _stopMenu.SetActive(false);
        _stopButton.SetActive(true);
        _buttonRestInGame.SetActive(true);
        Time.timeScale = 1;
        //добавить отсчет до продолжения
        //вкл звуки
    }

    public void Restart()
    {
        PlayerPrefs.SetInt("Money", money);
        SceneManager.LoadScene(1);
        MovingVagon.speed = 3;
        Time.timeScale = 1;
    }

    public void Change()
    {
        music.volume = sliderVolume.value;
        if (player.audio!=null)
        {
            player.audio.volume = sliderVolume.value;
        }
        PlayerPrefs.SetFloat("Volume", sliderVolume.value);
    }

    public void GoToMenu()
    {  
        PlayerPrefs.SetInt("Money", money);
        SceneManager.LoadScene(0,LoadSceneMode.Single);
    }

}
