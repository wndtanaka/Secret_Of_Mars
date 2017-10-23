using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    protected Transform target;
    [Header("Tower Attributes")]
    public float range;
    public float attackSpeed;
    public float damage;
    protected float attackTimer = 1f;
    protected float rotSpeed = 10f;

    [Header("References")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Transform rotCannon;
    private string enemyTag = "Enemy";

    // Use this for initialization
    protected virtual void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.2f);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (target == null)
            return;
        // look for target
        LockOnTarget();

        //if (attackTimer <= 0f)
        //{
        //    Attack();
        //    attackTimer = 1f / attackSpeed;
        //}
        //attackTimer -= Time.deltaTime;
        if (attackTimer >= attackSpeed)
        {
            Attack();
            attackTimer = 0;
        }
        attackTimer += Time.deltaTime;
    }
    protected virtual void LockOnTarget()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 cannonRotation = Quaternion.Lerp(rotCannon.rotation, lookRotation, Time.deltaTime * rotSpeed).eulerAngles;
        rotCannon.rotation = Quaternion.Euler(0f, cannonRotation.y, 0f);
    }

    protected virtual void Attack()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation) as GameObject;
        Projectile projectile = bulletGO.GetComponent<Projectile>();
        projectile.direction = target.position - transform.position;
        if (projectile != null)
        {
            projectile.Fire(target);
        }
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float closest = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < closest)
            {
                closest = distance;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && closest <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
