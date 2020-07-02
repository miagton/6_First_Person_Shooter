using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    [SerializeField] float restoreIntensity = 8f;
    [SerializeField] float restoreAngle = 40f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponentInChildren<FlashLIght>().RestoreLight(restoreIntensity, restoreAngle);
            Destroy(gameObject);
        }
    }
}
