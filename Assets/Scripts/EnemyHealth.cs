using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float enemyHealth = 100;
    [SerializeField] AudioClip deathSFX = null;

    Animator animator;
    NavMeshAgent agent;
    AudioSource audioSource;
    bool isDead = false;
   
    private void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Die()
    {
        if (isDead) return;
        isDead = true;
        audioSource.PlayOneShot(deathSFX, 3f);
        //gameObject.GetComponent<EnemyAi>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
       
        animator.ResetTrigger("Move");
        animator.SetTrigger("Die");
      
        agent.isStopped = true;
        //Destroy(gameObject);
    }

    public void ReciveDamage(float damage)
    {
        BroadcastMessage("SetProvoke");
        enemyHealth-=damage;
        if (enemyHealth < 1)
        {
            Die();
        }
       
    }

    public bool IsDead()
    {
        return isDead;
    }
}
