using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MySO/FoodItemInfo")]
public class FoodItemInfo : ItemInfo{//道具相關所有數據
	
	public int hungerPoints;
	
	public override void OnClick(){
		PlayerData.Instance.Hunger += hungerPoints;
		PlayerData.Instance.RemoveItem(this);
	}
}