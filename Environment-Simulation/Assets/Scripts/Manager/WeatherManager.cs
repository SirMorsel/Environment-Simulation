using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem snowFall;
    [SerializeField] private float intensity = 1.0f;
    [SerializeField] private float changeIntensityMaxTimer = 5.0f;
    private float changeIntensityTimer;

    // Start is called before the first frame update
    void Start()
    {
        changeIntensityTimer = changeIntensityMaxTimer;
    }

    // Update is called once per frame
    void Update()
    {
        changeIntensityTimer -= Time.deltaTime;
        if (changeIntensityTimer <= 0)
        {
            ChangeIntensity();
            changeIntensityTimer = changeIntensityMaxTimer;
        }
        
    }

    private void ChangeIntensity()
    {
        var main = snowFall.main;
        main.simulationSpeed = intensity;
    }
}
