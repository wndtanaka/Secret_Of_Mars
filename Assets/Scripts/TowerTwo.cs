using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTwo : Tower
{

    protected override void Start()
    {
        base.Start();
        range = 7;
        attackSpeed = 1;
        damage = 20;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void Attack()
    {
        base.Attack();
    }
}
