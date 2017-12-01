using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaveSpawner : MonoBehaviour
{
    public Transform[] waveOne;
    public Transform[] waveTwo;
    public Transform[] waveThree;
    public Transform[] waveFour;
    public Transform[] waveFive;
    public Transform[] waveSix;
    public Transform[] spawnPoint;
    public Text waveCountdownText;
    public GameObject stageClearUI;
    public GameObject gameOverUI;
    private GameObject countDown;

    [HideInInspector]
    public static int numberOfEnemies;

    [HideInInspector]
    public float timer = 10;
    private int waveCount = 0;
    private int levelIndicator;

    void Start()
    {
        //countDown = GameObject.Find("Countdown");
        //waveCountdownText = countDown.GetComponent<Text>();
    }

    private void Update()
    {
        if (numberOfEnemies > 0)
        {
            return;
        }
        if (timer <= 0f)
        {
            if (SceneManager.GetActiveScene().name == "Level1")
            {
                StartCoroutine(SpawnWaveLevel1());
            }
            if (SceneManager.GetActiveScene().name == "Level2")
            {
                StartCoroutine(SpawnWaveLevel2());
            }
            if (SceneManager.GetActiveScene().name == "Level3")
            {
                StartCoroutine(SpawnWaveLevel3());
            }
            timer = 5f;
            return;
        }
        timer -= Time.deltaTime;
        waveCountdownText.text = Mathf.Round(timer).ToString();
    }

    IEnumerator SpawnWaveLevel1()
    {
        waveCount++;
        if (waveCount == 1)
        {
            int totalEnemies = 5;
            for (int i = 0; i < totalEnemies; i++)
            {
                Instantiate(waveOne[i], spawnPoint[Random.Range(0, spawnPoint.Length)].position, spawnPoint[Random.Range(0, spawnPoint.Length)].rotation);
                numberOfEnemies++;
                yield return new WaitForSeconds(1f);
            }
        }
        else if (waveCount == 2)
        {
            int totalEnemies = 15;
            for (int i = 0; i < totalEnemies; i++)
            {
                Instantiate(waveTwo[i], spawnPoint[Random.Range(0, spawnPoint.Length)].position, spawnPoint[Random.Range(0, spawnPoint.Length)].rotation);
                numberOfEnemies++;
                yield return new WaitForSeconds(1f);
            }
        }
        else if (waveCount == 3)
        {
            int totalEnemies = 5;
            for (int i = 0; i < totalEnemies; i++)
            {
                Instantiate(waveThree[i], spawnPoint[Random.Range(0, spawnPoint.Length)].position, spawnPoint[Random.Range(0, spawnPoint.Length)].rotation);
                numberOfEnemies++;
                yield return new WaitForSeconds(1f);
            }
        }
        else if (waveCount == 4)
        {
            int totalEnemies = 10;
            for (int i = 0; i < totalEnemies; i++)
            {
                Instantiate(waveFour[i], spawnPoint[Random.Range(0, spawnPoint.Length)].position, spawnPoint[Random.Range(0, spawnPoint.Length)].rotation);
                numberOfEnemies++;
                yield return new WaitForSeconds(1f);
            }
        }
        else if (waveCount == 5)
        {
            int totalEnemies = 6;
            for (int i = 0; i < totalEnemies; i++)
            {
                Instantiate(waveFive[i], spawnPoint[Random.Range(0, spawnPoint.Length)].position, spawnPoint[Random.Range(0, spawnPoint.Length)].rotation);
                numberOfEnemies++;
                yield return new WaitForSeconds(1f);
            }
        }
        else if (waveCount == 6)
        {
            int totalEnemies = 50;
            for (int i = 0; i < totalEnemies; i++)
            {
                Instantiate(waveSix[i], spawnPoint[Random.Range(0, spawnPoint.Length)].position, spawnPoint[Random.Range(0, spawnPoint.Length)].rotation);
                numberOfEnemies++;
                yield return new WaitForSeconds(0.5f);
            }
        }
        else if (waveCount >= 7)
        {
            //SceneManager.LoadScene("Level2");
            if (!gameOverUI.activeSelf && !stageClearUI.activeSelf)
            {
                stageClearUI.SetActive(true);
            }
        }
    }

    IEnumerator SpawnWaveLevel2()
    {
        waveCount++;
        if (waveCount == 1)
        {
            int totalEnemies = 10;
            for (int i = 0; i < totalEnemies; i++)
            {
                Instantiate(waveOne[i], spawnPoint[Random.Range(0, spawnPoint.Length)].position, spawnPoint[Random.Range(0, spawnPoint.Length)].rotation);
                numberOfEnemies++;
                yield return new WaitForSeconds(1f);
            }
        }
        else if (waveCount == 2)
        {
            int totalEnemies = 15;
            for (int i = 0; i < totalEnemies; i++)
            {
                Instantiate(waveTwo[i], spawnPoint[Random.Range(0, spawnPoint.Length)].position, spawnPoint[Random.Range(0, spawnPoint.Length)].rotation);
                numberOfEnemies++;
                yield return new WaitForSeconds(1f);
            }
        }
        else if (waveCount == 3)
        {
            int totalEnemies = 10;
            for (int i = 0; i < totalEnemies; i++)
            {
                Instantiate(waveThree[i], spawnPoint[Random.Range(0, spawnPoint.Length)].position, spawnPoint[Random.Range(0, spawnPoint.Length)].rotation);
                numberOfEnemies++;
                yield return new WaitForSeconds(1f);
            }
        }
        else if (waveCount == 4)
        {
            int totalEnemies = 25;
            for (int i = 0; i < totalEnemies; i++)
            {
                Instantiate(waveFour[i], spawnPoint[Random.Range(0, spawnPoint.Length)].position, spawnPoint[Random.Range(0, spawnPoint.Length)].rotation);
                numberOfEnemies++;
                yield return new WaitForSeconds(1f);
            }
        }
        else if (waveCount == 5)
        {
            int totalEnemies = 40;
            for (int i = 0; i < totalEnemies; i++)
            {
                Instantiate(waveFive[i], spawnPoint[Random.Range(0, spawnPoint.Length)].position, spawnPoint[Random.Range(0, spawnPoint.Length)].rotation);
                numberOfEnemies++;
                yield return new WaitForSeconds(1f);
            }
        }
        else if (waveCount == 6)
        {
            int totalEnemies = 70;
            for (int i = 0; i < totalEnemies; i++)
            {
                Instantiate(waveSix[i], spawnPoint[Random.Range(0, spawnPoint.Length)].position, spawnPoint[Random.Range(0, spawnPoint.Length)].rotation);
                numberOfEnemies++;
                yield return new WaitForSeconds(0.5f);
            }
        }
        else if (waveCount >= 7)
        {
            if (!gameOverUI.activeSelf && !stageClearUI.activeSelf)
            {
                stageClearUI.SetActive(true);
            }
        }
        Debug.Log(waveCount);
    }

    IEnumerator SpawnWaveLevel3()
    {
        waveCount++;
        if (waveCount == 1)
        {
            int totalEnemies = 30;
            for (int i = 0; i < totalEnemies; i++)
            {
                Instantiate(waveOne[i], spawnPoint[Random.Range(0, spawnPoint.Length)].position, spawnPoint[Random.Range(0, spawnPoint.Length)].rotation);
                numberOfEnemies++;
                yield return new WaitForSeconds(0.5f);
            }
        }
        else if (waveCount == 2)
        {
            int totalEnemies = 60;
            for (int i = 0; i < totalEnemies; i++)
            {
                Instantiate(waveTwo[i], spawnPoint[Random.Range(0, spawnPoint.Length)].position, spawnPoint[Random.Range(0, spawnPoint.Length)].rotation);
                numberOfEnemies++;
                yield return new WaitForSeconds(0.5f);
            }
        }
        else if (waveCount == 3)
        {
            int totalEnemies = 100;
            for (int i = 0; i < totalEnemies; i++)
            {
                Instantiate(waveThree[i], spawnPoint[Random.Range(0, spawnPoint.Length)].position, spawnPoint[Random.Range(0, spawnPoint.Length)].rotation);
                numberOfEnemies++;
                yield return new WaitForSeconds(0.4f);
            }
        }
        else if (waveCount == 4)
        {
            int totalEnemies = 160;
            for (int i = 0; i < totalEnemies; i++)
            {
                Instantiate(waveFour[i], spawnPoint[Random.Range(0, spawnPoint.Length)].position, spawnPoint[Random.Range(0, spawnPoint.Length)].rotation);
                numberOfEnemies++;
                yield return new WaitForSeconds(0.3f);
            }
        }
        else if (waveCount == 5)
        {
            int totalEnemies = 300;
            for (int i = 0; i < totalEnemies; i++)
            {
                Instantiate(waveFive[i], spawnPoint[Random.Range(0, spawnPoint.Length)].position, spawnPoint[Random.Range(0, spawnPoint.Length)].rotation);
                numberOfEnemies++;
                yield return new WaitForSeconds(0.2f);
            }
        }
        else if (waveCount == 6)
        {
            int totalEnemies = 600;
            for (int i = 0; i < totalEnemies; i++)
            {
                Instantiate(waveSix[i], spawnPoint[Random.Range(0, spawnPoint.Length)].position, spawnPoint[Random.Range(0, spawnPoint.Length)].rotation);
                numberOfEnemies++;
                yield return new WaitForSeconds(0.1f);
            }
        }
        else if (waveCount >= 7)
        {
            if (!gameOverUI.activeSelf && !stageClearUI.activeSelf)
            {
                stageClearUI.SetActive(true);
            }
            waveCount = 0;
        }
    }

}
