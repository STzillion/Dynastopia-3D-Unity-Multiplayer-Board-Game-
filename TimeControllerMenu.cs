using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class TimeControllerMenu : MonoBehaviour
{

    public Material nightMaterial;
    public Light streetLight;
    public Light streetLightOne;
    public Light streetLightTwo;
 




    [SerializeField]
    private float timeMultiplier;

    [SerializeField]
    private float startHour;

    //  private TextMeshProUGUI timeText;

    [SerializeField]
    private Light sunLight;

    [SerializeField]
    private float sunriseHour;

    [SerializeField]
    private float sunsetHour;


    private DateTime currentTime;

    private TimeSpan sunriseTime;

    private TimeSpan sunsetTime;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = DateTime.Now.Date + TimeSpan.FromHours(startHour);

        sunriseTime = TimeSpan.FromHours(sunriseHour);
        sunsetTime = TimeSpan.FromHours(sunsetHour);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimeOfDay();
        RotateSun();
    }

    private void UpdateTimeOfDay()
    {
        currentTime = currentTime.AddSeconds(Time.deltaTime * timeMultiplier);

    }


    private void RotateSun()
    {
        float sunLightRotation;

        if (currentTime.TimeOfDay > sunriseTime && currentTime.TimeOfDay < sunsetTime)
        {
            TimeSpan sunriseToSunSetDuration = CalculateTimeDifference(sunriseTime, sunsetTime);
            TimeSpan timeSinceSunrise = CalculateTimeDifference(sunriseTime, currentTime.TimeOfDay);

            double percentage = timeSinceSunrise.TotalMinutes / sunriseToSunSetDuration.TotalMinutes;

            sunLightRotation = Mathf.Lerp(0, 180, (float)percentage);
            // nightMaterial.SetColor("_EmissionColor", Color.Lerp(Color.grey, Color.yellow, (float)percentage));
            nightMaterial.SetColor("_EmissionColor", Color.grey);

            sunLight.color = (Color.white);
            streetLight.range = (0f);
            streetLightOne.range = (0f);
            streetLightTwo.range = (0f);




        }
        else
        {
            TimeSpan sunsetToSunriseDuration = CalculateTimeDifference(sunsetTime, sunriseTime);
            TimeSpan timeSinceSunset = CalculateTimeDifference(sunsetTime, currentTime.TimeOfDay);

            double percentage = timeSinceSunset.TotalMinutes / sunsetToSunriseDuration.TotalMinutes;

            sunLightRotation = Mathf.Lerp(180, 360, (float)percentage);
            //  nightMaterial.SetColor("_EmissionColor", Color.Lerp(Color.yellow, Color.grey, (float)percentage));
            nightMaterial.SetColor("_EmissionColor", Color.yellow);
            streetLight.range = (3f);
            streetLightOne.range = (3f);
            streetLightTwo.range = (3f);
    


            sunLight.color = (Color.black);
        }

        sunLight.transform.rotation = Quaternion.AngleAxis(sunLightRotation, Vector3.right);
    }



    private TimeSpan CalculateTimeDifference(TimeSpan fromTime, TimeSpan toTime)
    {
        TimeSpan difference = toTime - fromTime;

        if (difference.TotalSeconds < 0)
        {
            difference += TimeSpan.FromHours(24);
        }
        return difference;
    }
}
