using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform[] waveOne;
    public Transform[] waveTwo;
    public Transform[] waveThree;
    public Transform[] waveFour;
    public Transform[] waveFive;
    public Transform[] spawnPoint;
    public Text waveCountdownText;

    private float timer = 10;
    private int waveCount = 0;

    private void Update()
    {
        timer -= Time.deltaTime;
        waveCountdownText.text = Mathf.Round(timer).ToString();
    }
    private IEnumerator Start()
    {
        timer = 10;
        if (timer >= 0)
        {
            waveCountdownText.enabled = true;
        }
        yield return new WaitForSeconds(timer);
        if (timer <= 0)
        {
            waveCountdownText.enabled = false;
        }
        timer -= Time.deltaTime;
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        waveCount++;
        if (waveCount == 1)
        {
            int totalEnemies = 10;
            for (int i = 0; i < totalEnemies; i++)
            {
                Instantiate(waveOne[i], spawnPoint[Random.Range(0, spawnPoint.Length)].position, spawnPoint[Random.Range(0, spawnPoint.Length)].rotation);
                yield return new WaitForSeconds(1f);
            }

            StartCoroutine(Start());
        }
        else if (waveCount == 2)
        {
            int totalEnemies = 8;
            for (int i = 0; i < totalEnemies; i++)
            {
                Instantiate(waveTwo[i], spawnPoint[Random.Range(0, spawnPoint.Length)].position, spawnPoint[Random.Range(0, spawnPoint.Length)].rotation);
                yield return new WaitForSeconds(1f);
            }
            StartCoroutine(Start());
        }
        else if (waveCount == 3)
        {
            int totalEnemies = 15;
            for (int i = 0; i < totalEnemies; i++)
            {
                Instantiate(waveThree[i], spawnPoint[Random.Range(0, spawnPoint.Length)].position, spawnPoint[Random.Range(0, spawnPoint.Length)].rotation);
                yield return new WaitForSeconds(2f);
            }
            StartCoroutine(Start());
        }
        else if (waveCount == 4)
        {
            int totalEnemies = 10;
            for (int i = 0; i < totalEnemies; i++)
            {
                Instantiate(waveFour[i], spawnPoint[Random.Range(0, spawnPoint.Length)].position, spawnPoint[Random.Range(0, spawnPoint.Length)].rotation);
                yield return new WaitForSeconds(1f);
            }
            StartCoroutine(Start());
        }
        else if (waveCount == 5)
        {
            int totalEnemies = 15;
            for (int i = 0; i < totalEnemies; i++)
            {
                Instantiate(waveFive[i], spawnPoint[Random.Range(0, spawnPoint.Length)].position, spawnPoint[Random.Range(0, spawnPoint.Length)].rotation);
                yield return new WaitForSeconds(0.5f);
            }
            StartCoroutine(Start());
        }
    }
}
