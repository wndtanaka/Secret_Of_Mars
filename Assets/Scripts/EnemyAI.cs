using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    public Transform EndPoint;
    private NavMeshAgent nav;
    CameraController camShake;

    // Use this for initialization
    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        camShake = Camera.main.GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EndPoint != null)
        {
            nav.SetDestination(EndPoint.position);
            nav.updateRotation = false;
        }
        else
        {
            Debug.LogError("Set Your EndPoint Prefab!");
        }
        if (!nav.pathPending)
        {
            if (nav.remainingDistance <= nav.stoppingDistance)
            {
                if (!nav.hasPath || nav.velocity.sqrMagnitude == 0f)
                {
                    Destroy(gameObject);
                    PlayerStats.curLives--;
                    WaveSpawner.numberOfEnemies--;
                    //camShake.Shake(0.1f,0.2f);
                }
            }
        }
    }
}
