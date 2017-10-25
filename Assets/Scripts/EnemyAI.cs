using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent nav;

    // Use this for initialization
    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            nav.SetDestination(target.position);
        }
        else
        {
            Debug.LogError("Set Your Target Prefab!");
        }
        if (!nav.pathPending)
        {
            if (nav.remainingDistance <= nav.stoppingDistance)
            {
                if (!nav.hasPath || nav.velocity.sqrMagnitude == 0f)
                {
                    Destroy(gameObject);
                    PlayerStats.curLives--;
                }
            }
        }
    }
}
