using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameTimeManager : MonoBehaviour{
    public static Action<DateTime> OnTimeChanged;
    public static Action OnWeekChanged;
    public static Action OnMonthChanged;
    
    [SerializeField]
    private float TimeSpeed = 1;

    public static DateTime Time{ private set; get; }

    void Start(){
        Time = new DateTime(1,1,1,7,00,0);
        StartCoroutine(TimeCtrl());
    }

    IEnumerator TimeCtrl(){
        yield return new WaitForSeconds(1);
        var newTime = Time.Add(TimeSpan.FromMinutes(TimeSpeed));
        
        if(newTime.DayOfWeek!=Time.DayOfWeek)OnWeekChanged?.Invoke();
        if(newTime.Month!=Time.Month)OnMonthChanged?.Invoke();
        
        Time = newTime;
        OnTimeChanged.Invoke(Time);
        Debug.Log(Time);
        yield return TimeCtrl();
    }
}
