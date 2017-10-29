using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAxe : Weapon
{
    public override void Fire(Transform enemy)
    {
        target = enemy;
    }

    protected override void LateUpdate()
    {
        if (target == null)
        {
            Destroy(gameObject);
        }
    }
    protected override void DealDamage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
