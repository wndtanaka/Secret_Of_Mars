using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerOne : Tower
{
    
    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        range = 7;
        attackSpeed = 0.8f;
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
