using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MySO/HouseSO")]
public class HouseSO: ScriptableObject{
    public bool PlayerLivesHere;
    public DateTime LastRentTime;
    
    public int Rent;
    public int Price;
    public int SocialScoreNeeded;
    public int comfortLevel;
}

public class HouseData{
    
}
