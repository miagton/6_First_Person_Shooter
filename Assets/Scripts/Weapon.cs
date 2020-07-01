using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] float weaponRange = 100f;

    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, weaponRange))
        {
         print("I hit :" + hit.collider.name);

        }
        

    }
}
