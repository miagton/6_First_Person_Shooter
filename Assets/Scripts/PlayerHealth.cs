using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject damageEffect = null;
    [SerializeField] float displayTIme = 1.5f;

    private void Awake()
    {
        damageEffect.SetActive(false);
    }
    public void DamagePlayer(float damage)
    {
        StartCoroutine(DisplayDamageEffect());
        health -= damage;
       
        if (health <= 1)
        {
            GetComponent<DeathHandler>().StartDeathScenario();
           
        }
    }

    IEnumerator DisplayDamageEffect()
    {
        damageEffect.SetActive(true);
        yield return new WaitForSeconds(displayTIme);
        damageEffect.SetActive(false);
    }
    
}
