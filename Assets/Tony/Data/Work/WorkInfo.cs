using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MySO/WorkInfo")]
public class WorkInfo : ScriptableObject{
	public string Name;
	
	public int OpenTime;
	public int CloseTime;
	
	public int MinWorkHour;
	public int MaxWorkHour;

	public RankInfo[] RankList;
}

[Serializable]
public struct RankInfo{
	public string Name;
	public int Salary;
	public int WorkHourNeed;

	public int HungryCost;
	public int EnergyCost;
	public int HygieneCost;
}

public class WorkData{
	public WorkInfo Info;
	public float TotalWorkHour;
	public int RankIndex;

	public WorkData(WorkInfo info, float totalWorkHour,int rankIndex){
		Info = info;
		TotalWorkHour = totalWorkHour;
		RankIndex = rankIndex;
	}
}