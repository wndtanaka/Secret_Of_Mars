using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFireBall : Weapon
{
    public float damageOverTime = 5;
    public float fireballAOE = 2f;
    public GameObject fireGround;

    protected override void DealDamage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }
    protected override void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector3 velocity = new Vector3(0,-5, 0).normalized * speed;
        transform.position += velocity * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            Destroy(gameObject);
        }
        FireBallAOE();
    }
    protected override void LateUpdate()
    {
        if (target == null)
        {
            Destroy(gameObject);
        }
    }
    void FireBallAOE()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, fireballAOE);
        foreach (Collider col in colliders)
        {
            if (col.tag == "Enemy")
            {
                DealDamage(col.transform);
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fireballAOE);
    }
    void OnDestroy()
    {
        GameObject fire =  Instantiate(fireGround,transform.position,transform.rotation) as GameObject;
        Destroy(fire, 3f);
    }
}
