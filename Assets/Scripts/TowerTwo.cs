using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTwo : Tower
{

    protected override void Start()
    {
        base.Start();
        range = 10;
        attackSpeed = 1;
        damage = 40;
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
