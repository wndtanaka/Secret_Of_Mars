using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAxe : Weapon
{
    public override void Fire(Transform enemy)
    {
        target = enemy;
    }
    protected override void DealDamage(Transform enemy)
    {
        if (target == null)
        {
            return;
        }
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }
        
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            DealDamage(target);
        }

    }
    protected override void Update()
    {
        if (target == null)
        {
            return;
        }
        // Homing
        //direction = target.position - transform.position;
        //float distanceThisFrame = speed * Time.deltaTime;
        //if (direction.magnitude <= distanceThisFrame)
        //{
        //    DealDamage(target);
        //    return;
        //}
        //transform.Translate(direction.normalized * distanceThisFrame, Space.World);

        // Not Homing (Miss)
        Vector3 velocity = direction.normalized * speed;
        transform.position += velocity * Time.deltaTime;
    }
    protected override void LateUpdate()
    {
        if (target == null)
        {
            return;
        }
    }
}
