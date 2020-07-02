using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{

    [SerializeField] AmmoSlots[] ammunition;

    [System.Serializable]
    private class AmmoSlots
    {
        public AmmoType ammoTYpe;
        public int ammoAmount;
    }
    public int GetAmmoAmount(AmmoType passedInType)
    {
        return CheckAmmoType(passedInType).ammoAmount;

        //foreach(var ammo in ammunition)
        //{
        //    if (ammo.ammoTYpe == ammoType)
        //    {
        //        return ammo.ammoAmount;
        //    }
        //}
        //return 0;

    }
    public void DecreaseAmmoAmount(AmmoType passedInType)
    {
        CheckAmmoType(passedInType).ammoAmount--;
        
        if (CheckAmmoType(passedInType).ammoAmount < 0)
        {
            CheckAmmoType(passedInType).ammoAmount = 0;
        }
    }
    public void IncreaseAmmoAmount(AmmoType passedInType,int amount)
    {
        CheckAmmoType(passedInType).ammoAmount += amount;
    }

        //foreach(var ammo in ammunition)
        //{
        //    if(ammo.ammoTYpe == ammoType)
        //    {
        //        ammo.ammoAmount--;
        //        if (ammo.ammoAmount <= 0)
        //        {
        //            ammo.ammoAmount = 0;
        //        }
        //    }
        //}

    
    private AmmoSlots CheckAmmoType(AmmoType type)
    {
        foreach(var ammo in ammunition)
        {
            if (ammo.ammoTYpe == type)
            {
                return ammo;
            }
        }
        return null;
    }
}
