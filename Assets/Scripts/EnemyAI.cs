using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    private GameObject EndPoint;
    private NavMeshAgent nav;

    // Use this for initialization
    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        EndPoint = GameObject.FindGameObjectWithTag("EndPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (EndPoint != null)
        {
            nav.SetDestination(EndPoint.transform.position);
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
