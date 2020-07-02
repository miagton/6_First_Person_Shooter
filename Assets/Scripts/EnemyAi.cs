using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    [SerializeField] float agroRadius = 20f;


    float distanceToPlayer = Mathf.Infinity;
    bool isProvoked = false;
    Transform player;
    NavMeshAgent agent;
    Animator animator;
    EnemyHealth health;
    private void Start()
    {
        player = FindObjectOfType<PlayerHealth>().transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        health = GetComponent<EnemyHealth>();
    }


    void Update()
    {
        if (health.IsDead()) return;
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
        transform.LookAt(player);
        animator.SetBool("isAttacking", true);
        
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

    public bool IsAgrovated()
    {
        return isProvoked;
    }
    public void SetProvoke()
    {
        isProvoked = true;
     Collider[] hitObjects=   Physics.OverlapSphere(transform.position, agroRadius);
        foreach(var obj in hitObjects)
        {
            
            if (obj.CompareTag("Enemy")&& !obj.gameObject.GetComponent<EnemyAi>().IsAgrovated())
            {
                obj.gameObject.GetComponent<EnemyAi>().SetProvoke();
            }
        }
    }
}
