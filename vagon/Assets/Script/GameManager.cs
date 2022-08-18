using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameOver = false;

    private float permissibleSpeed = 10;
    private float firstWave = 2;
    private float secondWave = 2.5f;
    private float thirdWave = 3;

    private void Start()
    {
      StartCoroutine(IncreaseSpeed());
    }

    IEnumerator IncreaseSpeed()
    {
        while (MovingVagon.speed<permissibleSpeed)
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
}
