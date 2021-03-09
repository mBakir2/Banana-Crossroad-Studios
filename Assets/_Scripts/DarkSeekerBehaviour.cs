using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum DarkSeekerState
{
    IDLE,
    RUN,
    ATTACK,
    DIE
}

public class DarkSeekerBehaviour : MonoBehaviour
{
    NavMeshAgent agent;
    private Animator animator;

    [Header("Line Of Sight")]
    public bool hasLos = false;
    public GameObject player;

    public float attackDistance;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasLos)
        {
            agent.SetDestination(player.transform.position);
        } 

        if (hasLos && Vector3.Distance(transform.position, player.transform.position) < attackDistance)
        {

            animator.SetInteger("AnimState", (int)DarkSeekerState.ATTACK);
            // look towards the player
            transform.LookAt(transform.position - player.transform.forward);
        }
        else
        {
            animator.SetInteger("AnimState", (int)DarkSeekerState.RUN);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            hasLos = true;
            player = other.transform.gameObject;
        }
    }
}
