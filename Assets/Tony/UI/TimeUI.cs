using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using TMPro;

public class TimeUI : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    
    private void OnEnable(){
        GameTimeManager.OnTimeChanged += UpdateTime;
    }

    private void OnDisable(){
        GameTimeManager.OnTimeChanged -= UpdateTime;
    }
    
    private void UpdateTime(DateTime date){
        timeText.text = date.ToString("HH:mm tt", CultureInfo.CreateSpecificCulture("en-US")); 
    }
}
