using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] int addAmount = 10;
    [SerializeField] AmmoType ammoType;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Ammo>().IncreaseAmmoAmount(ammoType, addAmount);
            Destroy(gameObject);
        }
    }

}
