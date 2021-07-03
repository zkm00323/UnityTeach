using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{
    public static Action OnMinuteChanged;
    public static Action OnHourChanged;

    public static int Minute { get; private set; } //make minute a property! 
    public static int Hour { get; private set; }

    [SerializeField]
    private float minuteToRealTime = 0.5f;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        Minute = 0;
        Hour = 7;
        timer = minuteToRealTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Minute++;
            OnMinuteChanged?.Invoke(); //?. means != null
            if (Minute>= 60)
            {
                Hour++;
                Minute = 0;
                OnHourChanged?.Invoke();
            }
            timer = minuteToRealTime;
        }
    }
}
