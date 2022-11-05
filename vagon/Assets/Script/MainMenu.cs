using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void LoadExtern(string date);

    private void Awake()
    {
        
    }
    public void PlayeGame()
   {
     
      SceneManager.LoadScene(1);
      Time.timeScale = 1;
      MovingVagon.speed = 3;   
   }

   public void Store()
   {
     SceneManager.LoadScene(2);
   }

   public void BeckToMenu()
   {
        SceneManager.LoadScene(0);
   }
   
}
