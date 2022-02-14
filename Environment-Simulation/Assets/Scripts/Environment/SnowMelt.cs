using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SnowMelt : MonoBehaviour
{
    [SerializeField] bool isOn = false;
    [SerializeField] float maxMeltTimerValue;
    [SerializeField] float meltMaxRange;
    

    private float snowLifeTime;
    private float currentMeltRange = 0;

    private float diffusionMeltCountdown;
    private float diffusionValue;

    private VisualEffect visualEffectSnowMelt;
    private GameObject fire;
    
    // Start is called before the first frame update
    void Start()
    {
        InitializeSettings();
    }

    // Update is called once per frame
    void Update()
    {
        MeltAndGrow();
    }

    private void InitializeSettings()
    {
        visualEffectSnowMelt = this.transform.GetChild(0).GetComponent<VisualEffect>();
        fire = this.transform.GetChild(1).gameObject;

        snowLifeTime = visualEffectSnowMelt.GetFloat("LifeTime");
        diffusionMeltCountdown = maxMeltTimerValue;
        diffusionValue = meltMaxRange / snowLifeTime * 0.5f;
        visualEffectSnowMelt.SetFloat("Size", 1f);
        fire.SetActive(false);
    }

    private void MeltAndGrow()
    {
        if (isOn)
        {
            if (currentMeltRange < meltMaxRange)
            {
                diffusionMeltCountdown -= Time.deltaTime;
                fire.SetActive(true);
                if (diffusionMeltCountdown <= 0)
                {
                    currentMeltRange += diffusionValue;
                    visualEffectSnowMelt.SetFloat("Size", currentMeltRange);
                    diffusionMeltCountdown = maxMeltTimerValue;
                }
            }
        }
        else
        {
            if (currentMeltRange > 0)
            {
                diffusionMeltCountdown -= Time.deltaTime;
                if (diffusionMeltCountdown <= 0)
                {
                    fire.SetActive(false);
                    currentMeltRange -= diffusionValue;
                    visualEffectSnowMelt.SetFloat("Size", currentMeltRange);
                    diffusionMeltCountdown = maxMeltTimerValue;
                }
            }
        }
    }

    public void ChangeIsOnState()
    {
        isOn = !isOn;
    }
} 
