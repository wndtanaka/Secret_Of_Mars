using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSix : Tower
{
    protected override void Start()
    {
        attackTimer = 5f;
        base.Start();
    }
    // Use this for initialization
    protected override void Attack()
    {
        GameObject fireBall = Instantiate(bulletPrefab, target.position + new Vector3(-3, 1, 0), firePoint.rotation) as GameObject;
        WeaponBlackHole projectile = fireBall.GetComponent<WeaponBlackHole>();
        if (projectile != null)
        {
            projectile.Fire(target);
        }
    }
}
