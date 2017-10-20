using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform target;
    public Vector3 direction;

    public float speed = 50f;

    public void Fire(Transform enemy)
    {
        target = enemy;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        // Homing
        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if (direction.magnitude <= distanceThisFrame)
        {
            TargetHit();
            return;
        }
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        // Not Homing (Miss)
        //Vector3 velocity = direction.normalized * speed;
        //transform.position += velocity * Time.deltaTime;
    }
    protected void TargetHit()
    {
        Debug.Log("Hit!");
        Destroy(gameObject);
        Destroy(target.gameObject);
    }
}
