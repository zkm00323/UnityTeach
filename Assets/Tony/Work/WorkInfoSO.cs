using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MySO/WorkInfo")]
public class WorkInfoSO : ScriptableObject{
	public string Name;
	
	public int OpenTime;
	public int CloseTime;
	
	public int MinWorkHour;
	public int MaxWorkHour;

	public RankInfo[] RankList;

    public WorkData GetGetData() //WorkData is a class that contains all the info in a specific job
    {
        return new WorkData(this, 0, 0); //0hour and 0 rank??
    }
}

[Serializable]
public struct RankInfo{
	public string Name;
	public int Salary;
	public int WorkHourNeed;
	public float MinSocialScore;

	public int HungryCost;
	public int EnergyCost;
	public int HygieneCost;

	[Header("Impact on Skills/Hr")]
	public int peopleSkillUp;
	public int brainPowerUp;
	public int staminaUp;
	public int charismaUp;
	public int cookingSkillUp;
	
}

public class WorkData{ //I FORGOT WHAT THIS IS FOR

	public WorkInfoSO Info;
	public float TotalWorkHour;
	public int RankIndex;

	public WorkData(WorkInfoSO info, float totalWorkHour,int rankIndex){ //constructor for class WorkData
		Info = info;
		TotalWorkHour = totalWorkHour;
		RankIndex = rankIndex;
	}
}