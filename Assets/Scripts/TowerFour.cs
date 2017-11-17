using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFour : Tower {

    protected override void Start()
    {
        attackTimer = 3f;
        base.Start();
    }
    // Use this for initialization
    protected override void Attack()
    {
        GameObject fireball = Instantiate(bulletPrefab, target.position + new Vector3(-2,5f,0), firePoint.rotation) as GameObject;
        WeaponFireBall projectile = fireball.GetComponent<WeaponFireBall>();
        //projectile.direction = target.position - transform.position;
        if (projectile != null)
        {
            projectile.Fire(target);
        }
    }
}
