using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private bool gameOver = false;

    // Update is called once per frame
    void Update()
    {
        if (gameOver) { return; }
        if (PlayerStats.curLives <= 0)
        {
            GameOver();
        }
    }
    void GameOver()
    {
        gameOver = true;
        Debug.Log("Game Over!");
    }
}
