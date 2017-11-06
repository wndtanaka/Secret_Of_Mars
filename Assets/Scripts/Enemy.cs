using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 3;
    public float startHealth = 50;
    private float health;
    public int loot = 25;
    private bool isDead = false;
    public NavMeshAgent nav;

    public Image healthBar;
    public GameObject enemyHealthBar;

    private void Start()
    {
        health = startHealth;
        nav = GetComponent<NavMeshAgent>();
        nav.speed = startSpeed;
        //healthBar = GetComponentInChildren<Image>();
    }
    public void TakeDamage(float damage)
    {
        startHealth -= damage;

        healthBar.fillAmount = startHealth / health;

        if (startHealth <= 0 && !isDead)
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
