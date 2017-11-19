using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerThreeLevel2 : Tower
{
    public LineRenderer laser;
    public bool useLaser = false;
    public int damageOverTime = 50;

    protected override void Start()
    {
        base.Start();
        range = 13;
        attackSpeed = 0.1f;
        damage = 10;
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (target == null)
        {
            if (useLaser)
            {
                if (laser.enabled)
                {
                    laser.enabled = false;
                }
            }
            return;
        }
        // look for target
        LockOnTarget();

        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (attackTimer >= attackSpeed)
            {
                Attack();
                attackTimer = 0;
            }
            attackTimer += Time.deltaTime;
        }
    }

    protected override void Attack()
    {
        base.Attack();
    }
    void Laser()
    {
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        if (!laser.enabled)
        {
            laser.enabled = true;
        }
        laser.SetPosition(0, firePoint.position);
        laser.SetPosition(1, target.position);
    }
}
