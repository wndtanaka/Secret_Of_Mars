using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform target;
    public Vector3 direction;

    public float speed = 50f;
    public int damage = 20;

    public void Fire(Transform enemy)
    {
        target = enemy;
    }

    // Update is called once per frame
    void Update()
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
    private void LateUpdate()
    {
        if (target == null)
        {
            Destroy(gameObject);
        }
    }
    protected void DealDamage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
