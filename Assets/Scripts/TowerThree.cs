using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerThree : Tower
{
    public Transform rightEye;
    public LineRenderer lineRendererLeft;
    public LineRenderer lineRendererRight;
    public bool useLaser = false;
    public int damageOverTime = 30;

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
                if (lineRendererLeft.enabled)
                {
                    lineRendererLeft.enabled = false;
                }
                if (lineRendererRight.enabled)
                {
                    lineRendererRight.enabled = false;
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
        if (!lineRendererLeft.enabled)
        {
            lineRendererLeft.enabled = true;
        }
        if (!lineRendererRight.enabled)
        {
            lineRendererRight.enabled = true;
        }
        lineRendererLeft.SetPosition(0, firePoint.position);
        lineRendererLeft.SetPosition(1, target.position);
        lineRendererRight.SetPosition(0, rightEye.position);
        lineRendererRight.SetPosition(1, target.position);
    }
}
