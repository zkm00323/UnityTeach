using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using TMPro;


public class TimeUI : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    
    private void Start(){
        GameTimeManager.RegisterTimeAciton(60,UpdateTime);
        //DontDestroyOnLoad(gameObject);
    }

    private void OnDisable(){
        //GameTimeManager.OnTimeChanged -= UpdateTime;
    }
    
    private void UpdateTime(){ //Time is a property in GameTimeManager
        timeText.text = GameTimeManager.Time.ToString("HH:mm tt", CultureInfo.CreateSpecificCulture("en-US"));
        //Debug.Log(GameTimeManager.Time);
    }
}
