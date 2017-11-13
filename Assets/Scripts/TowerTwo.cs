using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTwo : Tower
{

    protected override void Start()
    {
        base.Start();
        range = 7;
        attackSpeed = 10;
        damage = 20;
    }

    protected override void Attack()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation) as GameObject;
        WeaponLance projectile = bulletGO.GetComponent<WeaponLance>();
        projectile.direction = target.position - transform.position;
        if (projectile != null)
        {
            projectile.Fire(target);
        }
    }
}
