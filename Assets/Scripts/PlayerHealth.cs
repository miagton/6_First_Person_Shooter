using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DamagePlayer(float damage)
    {
        health -= damage;
        print("Health left" + health);
        if (health <= 1)
        {
            print("Player was killed!");
        }
    }
}
