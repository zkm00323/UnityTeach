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
	[SerializeField] private  Zoomer WorkZoomer;
	
	private WorkData Data;
	private double Value;
	public void Setup(WorkData data){
		RankInfo.text = data.Info.RankList[data.RankIndex].Name + "[" + data.Info.RankList[data.RankIndex].Salary + "$/h]";
		HungryCost.text = "Hunger Cost:" + data.Info.RankList[data.RankIndex].HungryCost + "h";
		EnergyCost.text = "Energy Cost:" + data.Info.RankList[data.RankIndex].EnergyCost + "h";
		HygieneCost.text = "Hygiene Cost:" + data.Info.RankList[data.RankIndex].HygieneCost + "h";
		Data = data;
		WorkZoomer.ZoomIn();
	}

	private void Update(){
		Value = Slider.value * (Data.Info.MaxWorkHour - Data.Info.MinWorkHour) * 2;
		Value = Math.Floor(Value);
		Value /= 2;
		Hour.text = Data.Info.MinWorkHour + Value + "h";

	}

	public void B_Confirm(){
		UICtrl.Instance.ConfirmWork(Data, Value);
	}

	public void B_Exit(){
		WorkZoomer.ZoomOut();
	}
}
