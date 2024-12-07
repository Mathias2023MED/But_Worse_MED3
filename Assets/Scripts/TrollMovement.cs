using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrollMovement : MonoBehaviour
{
    public NavMeshAgent troll;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    private Animator animator;

    // Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    // Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    // States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        troll = GetComponent<NavMeshAgent>();       
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Detect if the player is within sight or attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        // Call appropriate behavior based on player detection
        if (playerInAttackRange)
        {
            AttackPlayer();
        }
        else if (playerInSightRange)
        {
            ChasePlayer();
        }
        else
        {
            Patroling();
        }
    }

    private void Patroling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }

        if (walkPointSet)
        {
            troll.SetDestination(walkPoint);
            //animator.Play("walk"); // Play walk animation

            // Check if the troll has reached its patrol point
            Vector3 distanceToWalkPoint = transform.position - walkPoint;
            if (distanceToWalkPoint.magnitude < 1f)
            {
                walkPointSet = false; // Reset walk point
            }
        }
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        Vector3 potentialPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        NavMeshHit hit;

        // Ensure patrol point is on the NavMesh
        if (NavMesh.SamplePosition(potentialPoint, out hit, walkPointRange, NavMesh.AllAreas))
        {
            walkPoint = hit.position;
            walkPointSet = true;
        }
    }

    private void ChasePlayer()
    {
        if (troll.isOnNavMesh && player != null)
        {
            troll.SetDestination(player.position); // Move toward the player
        }
    }


    private void AttackPlayer()
    {
        troll.SetDestination(transform.position); // Stop moving
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            animator.Play("attack1"); // Play attack animation
            alreadyAttacked = true;

            // Attack cooldown logic
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
