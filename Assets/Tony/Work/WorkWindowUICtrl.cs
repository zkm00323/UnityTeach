using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkWindowUICtrl : MonoBehaviour
{
	[SerializeField] private Text Hour;
	[SerializeField] private Slider Slider;
	[SerializeField] private Text RankInfo;
	[SerializeField] private Text HungryCost;
	[SerializeField] private Text EnergyCost;
	[SerializeField] private Text HygieneCost;

	private WorkData Data;
	private double Value;
	public void Setup(WorkData data)
	{
		RankInfo.text = data.Info.RankList[data.RankIndex].Name + "[" + data.Info.RankList[data.RankIndex].Salary + "$/h]";
		HungryCost.text = "飢餓消耗:" + data.Info.RankList[data.RankIndex].HungryCost + "h";
		EnergyCost.text = "能量消耗:" + data.Info.RankList[data.RankIndex].EnergyCost + "h";
		HygieneCost.text = "衛生消耗:" + data.Info.RankList[data.RankIndex].HygieneCost + "h";
		Data = data;

	}

	private void Update()
	{
		//        最低2小時 最高8小時
		//        2+(0~1)*(8-2) = 2~8
		Value = Slider.value * (Data.Info.MaxWorkHour - Data.Info.MinWorkHour) * 2;
		Value = Math.Floor(Value);
		Value /= 2;
		Hour.text = Data.Info.MinWorkHour + Value + "h";

	}

	public void B_Confirm()
	{
		GameCtrl_.Instance.Work.GetSalary(Data, Value);
		GameCtrl_.Instance.Work.ImpactOnSkillPoints(Data, Value);

	}

	public void B_Exit()
	{

		GameCtrl_.Instance.Work.CloseWorkWindow();



	}
}
