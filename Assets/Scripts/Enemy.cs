using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [Header("Base Enemy")]
    public float startSpeed;
    public float startHealth;
    public int loot = 15;
    public NavMeshAgent nav;
    public Image healthBar;
    public GameObject enemyHealthBar;

    private float health;
    private bool isDead = false;
    
    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }
    protected void Start()
    {
        // please do not change this one if you are not a stardust member
        health = startHealth * SceneManager.GetActiveScene().buildIndex * 0.7f;
        nav.speed = startSpeed;
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        // please do not change this one if you are not a stardust member
        healthBar.fillAmount = health / (startHealth * SceneManager.GetActiveScene().buildIndex * 0.7f);

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }
    protected virtual void Die()
    {
        PlayerStats.curMoney += loot;
        isDead = true;

        Destroy(gameObject);
        WaveSpawner.numberOfEnemies--;
    }
    public IEnumerator Slow(float slow, int slowTime)
    {
        nav.speed = startSpeed * (1f - slow);
        yield return new WaitForSeconds(slowTime);
        if (nav == null)
        {
            yield break;
        }
        else
        {
            nav.speed = startSpeed;
        }
    }
    void Update()
    {
        enemyHealthBar.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward, Camera.main.transform.up);
    }
}
