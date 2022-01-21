using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DayNightCycle : MonoBehaviour //attach on sun in intro scene and disable suns in all the scenes
{

    public DateTime sunOutTime;
    public DateTime noonTime;
    private int timeDiff; //time difference in minutes
    public Material morningSkybox;
    public Material noonSkybox;
    public Material nightSkybox;
    



    [Range(0.0f, 1.0f)]
    public float time;
    public float fullDayLength;
    //public float startTime = 0.4f;
    //private float timeRate;
    public Vector3 noon; //rotation of sun at noon 

    public float rotationAngle= 15f; //sun rotates 15 degree every hour

    [Header("Sun")]
    public Light sun;
    public static Light _Sun;
    public Gradient sunColor;
    public AnimationCurve sunIntensity;


    [Header("Moon")]
    public Light moon;

    public Gradient moonColor;
    public AnimationCurve moonIntensity;

    [Header("Other Lighting Settings")]
    public AnimationCurve lightingIntensityMultiplier;
    public AnimationCurve reflectionsIntensityMultiplier;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        sunOutTime = new DateTime(1, 1, 1, 7, 00, 0);
        noonTime = new DateTime(1, 1, 1, 12, 00, 0);
        //sun.transform.localRotation = Quaternion.Euler(15, 0, 0);
        //_Sun = sun;
        //GameTimeManager.RegisterTimeAciton(60*60, SunRotates); //do sun intenesity and angle based on DateTime time
    }

   

    
    private void Update()
    {
        SunOut();
        Noon();
        SunDown();

        //make sure hour is equal;
    }

    public int GetDifference(DateTime now, DateTime timeOfEvent)
    {
        //when GameTimeManager.Time - Time you want the event to happen < 1; 
        //when GameTimeManager.Time > Time you want event to happen;
        //difference = GameTimeManager.Time.Subtract(DateTime(1, 1, 1, 7, 00, 0)); //first year, month, day, 7AM 0 seconds
        //return 


        timeDiff= (now - timeOfEvent).Minutes;
        return timeDiff;



        //return new DateTime(Begin.Ticks + gameTickDiff);
    }


    public void SunOut()
    {
        if (GameTimeManager.Time.Hour == 7)
        {
           if( GetDifference(GameTimeManager.Time, sunOutTime)== 7) //at 7:07AM sun comes out
            {
                GetComponent<Light>().intensity = 1.5f;
                Debug.Log("Sun comes out");
                
                RenderSettings.skybox = morningSkybox;


            }
        }
    }

    public void Noon()
    {
        if (GameTimeManager.Time.Hour == 12)
        {
            if (GetDifference(GameTimeManager.Time, noonTime ) == 1) //at 12:01
            {
                GetComponent<Light>().intensity = 2f;
                RenderSettings.skybox = noonSkybox;

            }

        }
    }

    public void SunDown()
    {
        if(GameTimeManager.Time.Hour == 6)
        {
            //if (GetDifference(GameTimeManager.Time, timeofEvent) == 1)
        }
    }


    /*void SunRotates()
    {
        // _Sun.transform.RotateAround(Vector3.zero, Vector3.right, rotationAngle);

        //do Mathf.PingPong ??
    }

    void SunIntensity()
    {

    }*/


}
