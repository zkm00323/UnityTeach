using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MySO/HouseSO")]
public class HouseSO: ScriptableObject{
    public bool PlayerLivesHere= false;
    public DateTime LastRentTime;
    
    public int Rent;
    public int Price;
    public int SocialScoreNeeded;
    public int comfortLevel;

    public List<FurnitureData> FurnitureList;
}

[Serializable]
public class FurnitureData{
    public Vector3 Pos;
    public Vector3 Rot;
    public GameObject Prefeb;
    public FurnitureData(Vector3 pos, Vector3 rot, GameObject prefeb){
        Pos = pos;
        Rot = rot;
        Prefeb = prefeb;
    }
}
