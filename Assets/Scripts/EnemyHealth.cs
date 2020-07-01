using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float enemyHealth = 100;

   

    
    

    private void Die()
    {
        Destroy(gameObject);
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
