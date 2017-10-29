using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected Transform target;
    [HideInInspector]
    public Vector3 direction;

    public float speed;
    public int damage;

    public virtual void Fire(Transform enemy)
    {
        target = enemy;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        // Homing
        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if (direction.magnitude <= distanceThisFrame)
        {
            DealDamage(target);
            return;
        }
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        // Not Homing (Miss)
        //Vector3 velocity = direction.normalized * speed;
        //transform.position += velocity * Time.deltaTime;
        
    }
    protected virtual void LateUpdate()
    {
        if (target == null)
        {
            Destroy(gameObject);
        }
    }
    protected virtual void DealDamage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
