using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    [SerializeField] Transform player = null;
    [SerializeField] float agroRadius = 20f;


    float distanceToPlayer = Mathf.Infinity;
    NavMeshAgent agent;
    Animator animator;
    bool isProvoked = false;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (isProvoked)
        {
            EngadgeTarget();
        }
        else if(distanceToPlayer <= agroRadius)
        {
            isProvoked = true;
        }
    }

    private void EngadgeTarget()
    {
        if (distanceToPlayer > agent.stoppingDistance)
        {
            Chase();

        }
        if (distanceToPlayer <= agent.stoppingDistance)
        {
            Attack();
        }
    }

    private void Attack()
    {
        animator.SetBool("isAttacking", true);
        print("Attacking" + player.name);
    }

    private void Chase()
    {
        isProvoked = true;
       
        animator.SetBool("isAttacking", false);
        animator.SetTrigger("Move");
       
        agent.SetDestination(player.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, agroRadius);
    }
    public void SetProvoke(bool setValue)
    {
        isProvoked = setValue;
    }
}
