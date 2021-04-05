using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/**
 * Authors: Anmoldeep Singh Gill
 *          Chadwick Lapis
 *          Mohammad Bakir
 * Last Modified on: 21th Mar 2020
 */
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

    [Header("Attack")]
    public float attackDistance;
    public PlayerBehaviour playerBehaviour;
    public float cooldown = 1f;
    private float lastAttackedAt = -9999f;
    public int damageAmount = 10;

    [Header("Health")]
    [Range(0, 100)]
    public int health = 100;
    public HealthBarScreenSpaceController enemyHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        playerBehaviour = FindObjectOfType<PlayerBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            animator.SetInteger("AnimState", (int)DarkSeekerState.DIE);
            StartCoroutine(DestroyEnemyAfterSpecifiedTime(gameObject, 3));
        } 
        else
        {
            if (hasLos)
            {
                agent.SetDestination(player.transform.position);

                if (hasLos && Vector3.Distance(transform.position, player.transform.position) < attackDistance)
                {
                    // look towards the player
                    transform.LookAt(transform.position - player.transform.forward);

                    //cooldown to do the attack after specified intervals
                    if (Time.time > lastAttackedAt + cooldown)
                    {
                        animator.SetInteger("AnimState", (int)DarkSeekerState.ATTACK);
                        playerBehaviour.TakeDamage(damageAmount);
                        lastAttackedAt = Time.time;
                    }
                }
                else
                {
                    animator.SetInteger("AnimState", (int)DarkSeekerState.RUN);
                }
            }
            else
            {
                animator.SetInteger("AnimState", (int)DarkSeekerState.IDLE);
            }
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

    public void TakeDamage(int damage)
    {
        Debug.Log("Taking Damage" + damage);
        if (health >= 0)
        {
            health -= damage;
            enemyHealthBar.TakeDamage(damage);
        } 
        else
        {
            health = 0;
        }
    }

    private IEnumerator DestroyEnemyAfterSpecifiedTime(GameObject enemy, float delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy(enemy);
    }
}
