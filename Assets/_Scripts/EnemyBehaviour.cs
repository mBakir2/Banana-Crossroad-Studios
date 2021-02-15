using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent myNavMeshAgent;
    public Transform player;
    void Start()
    {
        myNavMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
            myNavMeshAgent.SetDestination(player.position);
       
    }
}
