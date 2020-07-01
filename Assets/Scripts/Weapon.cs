using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [Header("VFX")]
    [SerializeField] ParticleSystem shootEffect;
    [SerializeField] GameObject hitEffect;
    
    [Header("Weapon attributes")]
    [SerializeField] float weaponRange = 100f;
    [SerializeField] float weaponDamage = 25f;

    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        PlayShootEffect();
        ProccesRaycast();

    }

    private void PlayShootEffect()
    {
        shootEffect.Play();
    }

    private void ProccesRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, weaponRange))
        {
            CreateHitEffect(hit);
           
            if (hit.transform.CompareTag("Enemy"))
            {

                hit.transform.gameObject.GetComponent<EnemyHealth>().ReciveDamage(weaponDamage);
                hit.transform.gameObject.GetComponent<EnemyAi>().SetProvoke(true);

            }
        }
        else
        {
            return;
        }
    }

    private void CreateHitEffect(RaycastHit hit)
    {
       GameObject impactVFX= Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactVFX, 0.2f);
    }
}
