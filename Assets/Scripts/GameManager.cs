using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject stageClearUI;
    public static bool gameOver;

    WaveSpawner waveSpawner;

    private void Start()
    {
        gameOver = false;
        waveSpawner = GetComponent<WaveSpawner>();
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
        WaveSpawner.numberOfEnemies = 0;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name.ToString());
    }

    public void NextLevel()
    {
        if (stageClearUI.activeSelf)
        {
            stageClearUI.SetActive(false);
        }
        WaveSpawner.numberOfEnemies = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Exit()
    {
        //Debug.Log("Back to Main Menu!");
        WaveSpawner.numberOfEnemies = 0;
        SceneManager.LoadScene(0); 
    }
}
