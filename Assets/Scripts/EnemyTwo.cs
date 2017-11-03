﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwo : Enemy
{
    public float spawnRadius = 6f;
    public GameObject wormPrefab;
    protected override void Die()
    {
        base.Die();
        for (int i = 0; i < 3; i++)
        {
            Instantiate(wormPrefab, (Random.insideUnitSphere * spawnRadius) + transform.position, transform.rotation);
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}