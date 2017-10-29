using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerOne : Tower
{
    Animator anim;
    WeaponAxe axe;
    // Use this for initialization
    protected override void Start()
    {
        anim = GetComponent<Animator>();
        base.Start();
        range = 5;
        attackSpeed = 0.5f;
        damage = 100;

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
        anim.SetBool("isAttack", true);
        axe.Fire(target);
        
    }
    protected override void UpdateTarget()
    {
        base.UpdateTarget();
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag =="Enemy")
        {
            anim.SetTrigger("isAttack");
        }
    }
}
