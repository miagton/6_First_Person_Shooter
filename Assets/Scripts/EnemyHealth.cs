﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float enemyHealth = 100;

    Animator animator;
    NavMeshAgent agent;
   
    private void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Die()
    {

        gameObject.GetComponent<EnemyAi>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
       
        animator.ResetTrigger("Move");
        animator.SetTrigger("Die");
      
        agent.isStopped = true;
        //Destroy(gameObject);
    }

    public void ReciveDamage(float damage)
    {
        enemyHealth-=damage;
        if (enemyHealth < 1)
        {
            Die();
        }
       
    }
}
