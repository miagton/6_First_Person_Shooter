using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;

    int weaponIndex;
   

  
    void Start()
    {
        SetWeaponActive();
    }
    void Update()
    {
        int previousWeapon = currentWeapon;

        ProccesKeyInput();
        ProccsScrollWheel();

        if (previousWeapon != currentWeapon)
        {
            SetWeaponActive();
        }
    }

    private void ProccsScrollWheel()
    {
           
        if (Input.mouseScrollDelta.y < 0)
        {
            if (currentWeapon < transform.childCount - 1) { currentWeapon++;  }
            
            else { currentWeapon = 0;  }
        }
       
        if (Input.mouseScrollDelta.y > 0)
        {
            if (currentWeapon > 0) { currentWeapon--; }

            else { currentWeapon = transform.childCount - 1; }

        }
    }

    private void ProccesKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;
        }
    }

    private void SetWeaponActive()
    {
        weaponIndex = 0;
        foreach(Transform weapon in transform)
        {
            if (currentWeapon == weaponIndex)
            {
                weapon.gameObject.SetActive(true);
              //  weapon.GetComponent<WeaponZoom>().ResetZoom();
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }

   
}
