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
        GameObject blackHole = Instantiate(bulletPrefab, target.position + new Vector3(-2f, 15f, 0), firePoint.rotation) as GameObject;
        WeaponBlackHole projectile = blackHole.GetComponent<WeaponBlackHole>();
        projectile.direction = target.position - transform.position;
        if (projectile != null)
        {
            projectile.Fire(target);
        }
    }
}
