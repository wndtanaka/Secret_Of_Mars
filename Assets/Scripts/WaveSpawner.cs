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

    [HideInInspector]
    public static int numberOfEnemies;

    private float timer = 10;
    private int waveCount = 0;
    private int levelIndicator;

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
            SceneManager.LoadScene("Level2");
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
            SceneManager.LoadScene("Level3");
        }
    }
    IEnumerator SpawnWaveLevel3()
    {
        waveCount++;
        if (waveCount == 1)
        {
            int totalEnemies = 15;
            for (int i = 0; i < totalEnemies; i++)
            {
                Instantiate(waveOne[i], spawnPoint[Random.Range(0, spawnPoint.Length)].position, spawnPoint[Random.Range(0, spawnPoint.Length)].rotation);
                numberOfEnemies++;
                yield return new WaitForSeconds(1f);
            }
        }
        else if (waveCount == 2)
        {
            int totalEnemies = 30;
            for (int i = 0; i < totalEnemies; i++)
            {
                Instantiate(waveTwo[i], spawnPoint[Random.Range(0, spawnPoint.Length)].position, spawnPoint[Random.Range(0, spawnPoint.Length)].rotation);
                numberOfEnemies++;
                yield return new WaitForSeconds(1f);
            }
        }
        else if (waveCount == 3)
        {
            int totalEnemies = 50;
            for (int i = 0; i < totalEnemies; i++)
            {
                Instantiate(waveThree[i], spawnPoint[Random.Range(0, spawnPoint.Length)].position, spawnPoint[Random.Range(0, spawnPoint.Length)].rotation);
                numberOfEnemies++;
                yield return new WaitForSeconds(1f);
            }
        }
        else if (waveCount == 4)
        {
            int totalEnemies = 80;
            for (int i = 0; i < totalEnemies; i++)
            {
                Instantiate(waveFour[i], spawnPoint[Random.Range(0, spawnPoint.Length)].position, spawnPoint[Random.Range(0, spawnPoint.Length)].rotation);
                numberOfEnemies++;
                yield return new WaitForSeconds(1f);
            }
        }
        else if (waveCount == 5)
        {
            int totalEnemies = 120;
            for (int i = 0; i < totalEnemies; i++)
            {
                Instantiate(waveFive[i], spawnPoint[Random.Range(0, spawnPoint.Length)].position, spawnPoint[Random.Range(0, spawnPoint.Length)].rotation);
                numberOfEnemies++;
                yield return new WaitForSeconds(1f);
            }
        }
        else if (waveCount == 6)
        {
            int totalEnemies = 200;
            for (int i = 0; i < totalEnemies; i++)
            {
                Instantiate(waveSix[i], spawnPoint[Random.Range(0, spawnPoint.Length)].position, spawnPoint[Random.Range(0, spawnPoint.Length)].rotation);
                numberOfEnemies++;
                yield return new WaitForSeconds(0.5f);
            }
        }
        else if (waveCount >= 7)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}
