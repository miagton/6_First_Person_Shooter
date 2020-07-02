using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera = null;
    
    [Header("Values sensetivity controlling")]
    [Tooltip("Less number=>more zoom")]
    [SerializeField] float zoomPower = 20f;
    [SerializeField]float standartZoom=60f;
    [SerializeField] float zoomedInSensetivity = 0.5f;
    [SerializeField] float zoomedOutSensetivity = 2f;

    [SerializeField] bool isZoomable = true;

    bool isZoomed = false;
    RigidbodyFirstPersonController firstPerson ;

    private void Awake()
    {
        firstPerson = FindObjectOfType<RigidbodyFirstPersonController>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2") && isZoomable)
        {
            ProccesZooming();
        }
    }
    private void OnDisable()
    {
        ResetZoom();
    }

    private void ProccesZooming()
    {
        if (!isZoomed)
        {
            SetZoom();

        }
        else
        {
            ResetZoom();
        }
    }

    private void SetZoom()
    {
        isZoomed = true;
        fpsCamera.fieldOfView = zoomPower;
        firstPerson.mouseLook.XSensitivity = zoomedInSensetivity;
        firstPerson.mouseLook.YSensitivity = zoomedInSensetivity;
    }

    public void ResetZoom()
    {
        isZoomed = false;
        fpsCamera.fieldOfView = standartZoom;
        firstPerson.mouseLook.XSensitivity = zoomedOutSensetivity;
        firstPerson.mouseLook.YSensitivity = zoomedOutSensetivity;
    }
}
