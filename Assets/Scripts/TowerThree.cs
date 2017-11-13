using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerThree : Tower
{
    public LineRenderer lineRenderer;
    public bool useLaser = false;
    public int damageOverTime = 30;
    public float slow = 0.5f;

    protected override void Start()
    {
        base.Start();
        range = 10;
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
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
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
            targetEnemy.nav.speed = 10f;
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
        //targetEnemy.Slow(slow);
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            targetEnemy.nav.speed = targetEnemy.startSpeed;
        }
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);
    }
}
