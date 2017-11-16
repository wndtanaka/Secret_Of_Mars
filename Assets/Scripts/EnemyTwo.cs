using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwo : Enemy
{
    protected override void Start()
    {
        startHealth = 100;
        startSpeed = 5;
        loot = 25;
        base.Start();
    }
    protected override void Die()
    {
        base.Die();
    }

}
