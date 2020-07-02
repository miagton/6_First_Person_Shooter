using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] TextMeshProUGUI ammoText;
    [Header("VFX")]
    [SerializeField] ParticleSystem shootEffect;
    [SerializeField] GameObject hitEffect;
    
    [Header("Weapon attributes")]
    [SerializeField] float weaponRange = 100f;
    [SerializeField] float weaponDamage = 25f;
    [SerializeField] float timeBetweenShots = 0.3f;
    [SerializeField] AmmoType ammoType;

    [Header("Weapon sounds")]
    [SerializeField] AudioClip gunShot = null;
    [SerializeField] AudioClip emptyClip = null;

    bool canShoot = true;
    
    AudioSource audio;
    Ammo myAmmo;
    private void OnEnable()
    {
        canShoot = true;
    }
    private void Start()
    {
        audio = GetComponent<AudioSource>();
        myAmmo = FindObjectOfType<Ammo>();
    }
    void Update()
    {
        DisplayAmmo();
        if (Input.GetButtonDown("Fire1")&&canShoot)
        {
            
           StartCoroutine( Shoot());
        }
    }

    private void DisplayAmmo()
    {
        ammoText.text = "Ammo : " + myAmmo.GetAmmoAmount(ammoType).ToString();
    }

    private IEnumerator Shoot()
    {
        canShoot = false;
        int ammoLeft = myAmmo.GetAmmoAmount(ammoType);
       
        if (ammoLeft > 0)
        {
            ProccesFiring();
        }
        else
        {
            audio.PlayOneShot(emptyClip);
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;

    }

    private void ProccesFiring()
    {
        myAmmo.DecreaseAmmoAmount(ammoType);
        PlayShootingEffects();
        ProccesRaycast();
    }

    private void PlayShootingEffects()
    {
        audio.PlayOneShot(gunShot,0.5f);
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
