using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwo : Enemy
{

    // Use this for initialization
    protected override void Start()
    {
        startHealth = 60;
        startSpeed = 6;
        loot = 40;
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
