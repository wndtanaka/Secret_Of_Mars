using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLance : Weapon
{
    public int damageOverTime = 5;
    public float slow = 0.3f;
    public int slowTime = 2;


    protected override void DealDamage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
            StartCoroutine(e.Slow(slow,slowTime));
            Destroy(gameObject);
        }
    }
}
