using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLIght : MonoBehaviour
{
    [SerializeField] float lightDecay = 0.1f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minAngle = 40f;

    Light myLight;

    void Start()
    {
        myLight = GetComponent<Light>();
    }

    
    void Update()
    {
        DecayLight(lightDecay,angleDecay);
    }

    private void DecayLight(float light,float angle)
    {
        myLight.intensity -= light * Time.deltaTime;

        if (myLight.spotAngle >= minAngle)
        {
            myLight.spotAngle -= angle * Time.deltaTime;
        }
    }
    public void RestoreLight(float light, float angle)
    {
        myLight.intensity = light;
        myLight.spotAngle = angle;
    }
}
