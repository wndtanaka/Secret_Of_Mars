using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFireGroundDPS : Weapon
{
    public float damageOverTime = 5;
    public float burnAOE = 2;

    protected override void DealDamage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damageOverTime * Time.deltaTime);
        }
    }
    void OnTriggerStay()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, burnAOE);
        foreach (Collider col in colliders)
        {
            if (col.tag == "Enemy")
            {
                DealDamage(col.transform);
            }
        }
    }
    protected override void Update()
    {
    }
    protected override void LateUpdate()
    {
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, burnAOE);
    }
}
