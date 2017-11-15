using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSix : Tower
{
    public Collider box;
    protected override void Start()
    {
        attackTimer = 5f;
        base.Start();
    }
    // Use this for initialization
    protected override void Attack()
    {
        GameObject blackHole = Instantiate(bulletPrefab, target.position + new Vector3(-3, 1, 0), firePoint.rotation) as GameObject;
        WeaponBlackHole projectile = blackHole.GetComponent<WeaponBlackHole>();
        Destroy(projectile.gameObject, 6f);
        if (projectile != null)
        {
            projectile.Fire(target);
        }
    }
}
