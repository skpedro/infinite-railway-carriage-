using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Store : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private GameObject[] S_B;
    [SerializeField] private GameObject[] GreenButton;
    [SerializeField] private GameObject[] RedButton;
    [SerializeField] private AudioSource audio;

    private int money;
    private int[] cost = {200,500,1000,1500,2000,5000};

    void Start()
    { 
        audio.volume = PlayerPrefs.GetFloat("Volume");
        money = PlayerPrefs.GetInt("Money");
        Available();
        Cheked();
    }
    private void Update()
    {
        money = PlayerPrefs.GetInt("Money");
        moneyText.text = money.ToString();
        Cheked();
    }
    
    public void Buy(int indexButton)
    {    
        money -= cost[indexButton];
        S_B[indexButton].SetActive(true);
        GreenButton[indexButton].SetActive(false);
        PlayerPrefs.SetInt("Money",money);
        PlayerPrefs.SetInt("isBuying"+indexButton, 1);
        Available();
    }

    private void Available()
    {
        if (money>=cost[0])
        {
            GreenButton[0].SetActive(true);
        }
        else { GreenButton[0].SetActive(false); }
        if (money >= cost[1])
        {
            GreenButton[1].SetActive(true);
        }
        else { GreenButton[1].SetActive(false); }
        if (money >= cost[2])
        {
            GreenButton[2].SetActive(true);
        }
        else { GreenButton[2].SetActive(false); }
        if (money >= cost[3])
        {
            GreenButton[3].SetActive(true);
        }
        else { GreenButton[3].SetActive(false); }
        if (money >= cost[4])
        {
            GreenButton[4].SetActive(true);
        }
        else { GreenButton[4].SetActive(false); }
        if (money >= cost[5])
        {
            GreenButton[5].SetActive(true);
        }
        else { GreenButton[5].SetActive(false); }
    }

    private void Cheked()
    {
        if (PlayerPrefs.GetInt("isBuying0")==1)
        {
            S_B[0].SetActive(true);
            GreenButton[0].SetActive(false);
            RedButton[0].SetActive(false);
        }
        if (PlayerPrefs.GetInt("isBuying1") == 1)
        {
            S_B[1].SetActive(true);
            GreenButton[1].SetActive(false);
            RedButton[1].SetActive(false);
        }
        if (PlayerPrefs.GetInt("isBuying2") == 1)
        {
            S_B[2].SetActive(true);
            GreenButton[2].SetActive(false);
            RedButton[2].SetActive(false);
        }
        if (PlayerPrefs.GetInt("isBuying3") == 1)
        {
            S_B[3].SetActive(true);
            GreenButton[3].SetActive(false);
            RedButton[3].SetActive(false);
        }
        if (PlayerPrefs.GetInt("isBuying4") == 1)
        {
            S_B[4].SetActive(true);
            GreenButton[4].SetActive(false);
            RedButton[4].SetActive(false);
        }
        if (PlayerPrefs.GetInt("isBuying5") == 1)
        {
            S_B[5].SetActive(true);
            GreenButton[5].SetActive(false);
            RedButton[5].SetActive(false);
        }
    }

    public void Select(int index)
    {
        PlayerPrefs.SetInt("Player",index);
    } 
}
