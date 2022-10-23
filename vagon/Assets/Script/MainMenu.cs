using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
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
