using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public enum DetectionMode
    {
        ClosestToEnd = 0,
        ClosestToTower = 1,
        FurthestToEnd = 2,
        FurthestToTower = 3
    }
    protected Transform target;
    [Header("Tower Attributes")]
    public DetectionMode detectMode = DetectionMode.ClosestToTower;
    public float range;
    public float attackSpeed;
    public float damage;
    protected float attackTimer;
    protected float rotSpeed = 10f;

    [Header("References")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Transform rotCannon;
    private string enemyTag = "Enemy";
    protected Enemy targetEnemy;
    public Transform endPoint;

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
        Weapon projectile = bulletGO.GetComponent<Weapon>();
        projectile.direction = target.position - transform.position;
        if (projectile != null)
        {
            projectile.Fire(target);
        }
    }

    protected virtual void UpdateTarget()
    {
        GameObject nearestEnemy = null;

        switch (detectMode)
        {
            case DetectionMode.ClosestToEnd:
                nearestEnemy = GetClosestEnemyToPoint(endPoint.position);
                break;
            case DetectionMode.ClosestToTower:
                nearestEnemy = GetClosestEnemyToPoint(transform.position);
                break;
            case DetectionMode.FurthestToEnd:
                break;
            case DetectionMode.FurthestToTower:
                break;
            default:
                nearestEnemy = GetClosestEnemyToPoint(transform.position);
                break;
        }

        if (nearestEnemy != null)
        {
            float closest = Vector3.Distance(nearestEnemy.transform.position, transform.position);
            if (closest <= range)
            {
                target = nearestEnemy.transform;
                targetEnemy = nearestEnemy.GetComponent<Enemy>();
            }
        }
        else
        {
            target = null;
        }
    }

    GameObject GetClosestEnemyToPoint(Vector3 point)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float closest = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(point, enemy.transform.position);
            if (distance < closest)
            {
                closest = distance; 
                nearestEnemy = enemy;
            }
        }
        return nearestEnemy;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
