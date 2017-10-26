using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;

    public static bool gameOver;

    private void Start()
    {
        gameOver = false;
    }
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
        gameOverUI.SetActive(true);
    }
    public void Retry()
    {
        SceneManager.LoadScene(0);
    }
    public void Menu()
    {
        Debug.Log("Back to Main Menu!");
    }
}
