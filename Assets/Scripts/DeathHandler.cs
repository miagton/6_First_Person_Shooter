using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas deathCanvas = null;
    [SerializeField] GameObject weapon;

    RigidbodyFirstPersonController controller;
    private void Awake()
    {
        deathCanvas.enabled = false;
        controller = GetComponent<RigidbodyFirstPersonController>();
    }

   
   public void StartDeathScenario()
    {
       
            ResetCursor();
            Time.timeScale = 0;
            deathCanvas.enabled = true;
            weapon.SetActive(false);
            controller.enabled = false;
       
    }

    private  void ResetCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
