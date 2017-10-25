using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10;
    public float slowSpeed;
    public float health = 50;
    public int loot = 10;
    private bool isDead = false;
    public NavMeshAgent nav;

    private void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.speed = startSpeed;
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0 && !isDead)
        {
            Die();
        }
    }
    void Die()
    {
        PlayerStats.curMoney += loot;
        isDead = true;

        Destroy(gameObject);
    }
    public void Slow(float slow)
    {
        nav.speed = startSpeed * (1f - slow);
        //yield return new WaitForSeconds(3);
        //nav.speed = startSpeed;
    }
}
