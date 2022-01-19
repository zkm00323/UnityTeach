using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeChecker : MonoBehaviour
{
    public static Action<int> OnSevenAM = delegate { };

    //TimeChecker.morningEvents += listeners???

    public void CheckTime()
    {
        if (GameTimeManager.Time.Hour == 7)
        {
            //time trigger
        }
    }

}
