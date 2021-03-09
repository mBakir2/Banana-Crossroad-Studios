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
            animator.SetInteger("AnimState", (int)DarkSeekerState.RUN);

            if (Vector3.Distance(transform.position, player.transform.position) < 3.5) {

                animator.SetInteger("AnimState", (int)DarkSeekerState.ATTACK);
                // look towards the player
                transform.LookAt(transform.position - player.transform.forward);
            }
        } 
        else
        {
            animator.SetInteger("AnimState", (int)DarkSeekerState.IDLE);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            animator.SetInteger("AnimState", (int)DarkSeekerState.DIE);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            animator.SetInteger("AnimState", (int)DarkSeekerState.ATTACK);
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

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            hasLos = false;
        }
    }
}
