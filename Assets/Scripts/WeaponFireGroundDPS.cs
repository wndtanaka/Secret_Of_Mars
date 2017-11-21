using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFireGroundDPS : Weapon
{
    public float damageOverTime = 5;
    public float burnAOE = 2;
    public LayerMask enemyMask;
    private bool markForDestroy = false;

    protected override void DealDamage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damageOverTime * Time.deltaTime);
            Destroy(gameObject, 5f);
        }
    }
    void OnTriggerStay()
    {
        markForDestroy = true;
    }
    protected override void Update()
    {
        if (markForDestroy)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, burnAOE, enemyMask);
            for (int i = 0; i < colliders.Length; i++)
            {
                Collider col = colliders[i];
                DealDamage(col.transform);
            }
        }
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
