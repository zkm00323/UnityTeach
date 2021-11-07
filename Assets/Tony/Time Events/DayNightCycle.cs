using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
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

    private void Start()
    {
        
        sun.transform.localRotation = Quaternion.Euler(15, 0, 0);
        _Sun = sun;
        GameTimeManager.RegisterTimeAciton(60*60, SunRotates); //every 1 hour in game sun rotates//
    }

    void SunRotates() {
        _Sun.transform.RotateAround(Vector3.zero, Vector3.right, rotationAngle);
    }

    void SunIntensity()
    {

    }

}
