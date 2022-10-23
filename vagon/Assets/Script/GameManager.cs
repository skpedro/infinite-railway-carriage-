using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    private AudioSource music;

    public ParticleSystem particle;
    
    private PlayerController player;

    public TextMeshProUGUI _money;

    private bool gameOver = false;

    public static int money;
    public static int indexSckin;

    private float permissibleSpeed = 10;
    private float firstWave = 2;
    private float secondWave = 2.5f;
    private float thirdWave = 3;

    private void Start()
    {
        Instantiate(playerS[PlayerPrefs.GetInt("Player")], new Vector3(playerPos.position.x, playerPos.position.y, playerPos.position.z) ,Quaternion.identity);
        StartCoroutine(IncreaseSpeed());
        //Application.targetFrameRate = 200;  
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        money = PlayerPrefs.GetInt("Money");
        music = GetComponent<AudioSource>();
        music.volume = PlayerPrefs.GetFloat("Volume");
        sliderVolume.value = PlayerPrefs.GetFloat("Volume");
    }

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

    IEnumerator Wait(float sekond)
    {   
        while (true)
        {
            music.Stop();
            yield return new WaitForSeconds(sekond);
            _stopMenu.gameObject.SetActive(true);
           _buttonRestart.SetActive(true);
           _buttonContinue.SetActive(false);
            PlayerPrefs.SetInt("Money", money);
            //выключить звуки
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
        PlayerPrefs.SetInt("Money",money);
        SceneManager.LoadScene(1);
        MovingVagon.speed = 3;
        Time.timeScale = 1;
    }

    public void Change()
    {
        music.volume = sliderVolume.value;
        player.audio.volume = sliderVolume.value;
        PlayerPrefs.SetFloat("Volume", sliderVolume.value);
    }

    public void GoToMenu()
    {
        PlayerPrefs.SetInt("Money", money);
        SceneManager.LoadScene(0,LoadSceneMode.Single);
    }
}
