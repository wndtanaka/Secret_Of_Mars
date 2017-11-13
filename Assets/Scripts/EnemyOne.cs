using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOne : Enemy
{
    // Use this for initialization
    protected override void Start()
    {
        startSpeed = 2;
        startHealth = 70;
        loot = 20;
        base.Start();
    }
}
