using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;

    
    public void DamagePlayer(float damage)
    {
        health -= damage;
       
        if (health <= 1)
        {
            GetComponent<DeathHandler>().StartDeathScenario();
           
        }
    }

    
}
