using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeChecker : MonoBehaviour
{
    public static Action<int> morningEvents = delegate { };

    //TimeChecker.morningEvents += listeners???

    public void CheckTime()
    {
        if (GameTimeManager.Time.Hour == 10)
        {
            ///ningEvents();
        }
    }

}
