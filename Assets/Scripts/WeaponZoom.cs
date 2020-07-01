using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera = null;
    
    [Tooltip("Less number=>more zoom")]
    [SerializeField] float zoomPower = 20f;
    [SerializeField]float standartZoom=60f;
    
    bool isZoomed = false;

   
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            ProccesZooming();
        }
    }

    private void ProccesZooming()
    {
        if (!isZoomed)
        {
            isZoomed = true;
            fpsCamera.fieldOfView = zoomPower;
            
        }
        else
        {
            isZoomed = false;
            fpsCamera.fieldOfView = standartZoom;
        }
    }
}
