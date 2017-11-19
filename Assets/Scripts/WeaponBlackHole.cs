using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBlackHole : Weapon
{
    public float damageOverTime = 5;
    public float slow = 0.3f;
    public int slowTime = 3;
    public float blackHoleAOE = 0f;

    protected override void DealDamage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damageOverTime * Time.deltaTime);
            StartCoroutine(e.Slow(slow, slowTime));
            Destroy(gameObject, 6f);
        }
    }
    protected override void Update()
    {
        if (target == null)
        {
            return;
        }
        if (direction.magnitude > 0)
        {
            Vector3 velocity = new Vector3(0, -1, 0).normalized * speed;
            transform.position += velocity * Time.deltaTime;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        BlackHoleAoE();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            direction = Vector3.zero;
            Debug.Log("DIE");
        }
    }
    protected override void LateUpdate()
    {
        if (target == null)
        {
            return;
        }
    }
    void BlackHoleAoE()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, blackHoleAOE);
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
        Gizmos.DrawWireSphere(transform.position, blackHoleAOE);
    }
}
