using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerOneLevel2 : Tower
{
    Animator anim;
    public WeaponAxe left;
    public WeaponAxe right;
    // Use this for initialization

    protected override void Start()
    {
        anim = GetComponent<Animator>();
        base.Start();
        range = 5;
        attackSpeed = 0.5f;
        damage = 25;
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (target == null)
        {
            anim.SetBool("isAttack", false);
            return;
        }

        // look for target
        LockOnTarget();

        if (attackTimer >= attackSpeed)
        {
            Attack();
            attackTimer = 0;
        }
        attackTimer += Time.deltaTime;
    }

    protected override void Attack()
    {
        left.Fire(target);
        right.Fire(target);
        anim.SetBool("isAttack", true);
    }
    protected override void UpdateTarget()
    {
        base.UpdateTarget();
    }
}