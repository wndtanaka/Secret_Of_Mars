using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBlackHole : Weapon
{
    public float damageOverTime = 5;
    public float slow = 0.3f;
    public int slowTime = 3;
    public float blackHoleAOE = 0f;
    public LayerMask enemyMask;
    private bool markForDestroy = false;

    protected override void DealDamage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damageOverTime * Time.deltaTime);
            StartCoroutine(e.Slow(slow, slowTime));
            Destroy(gameObject, 5.9f);
        }
    }
    protected override void Update()
    {
        if (direction.magnitude > 0)
        {
            Vector3 velocity = new Vector3(0, -1, 0).normalized * speed;
            transform.position += velocity * Time.deltaTime;
        }
        if (markForDestroy)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, blackHoleAOE, enemyMask);
            for (int i = 0; i < colliders.Length; i++)
            {
                Collider col = colliders[i];
                DealDamage(col.transform);
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        markForDestroy = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            direction = Vector3.zero;
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z);
        }
    }
    protected override void LateUpdate()
    {
        if (target == null)
        {
            return;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, blackHoleAOE);
    }
}
