using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MySO/FoodItemInfo")]
public class FoodItemInfo : ItemInfoSO{//道具相關所有數據
	
	public int hungerPoints;
	public int energyPoints;
	
	public override void OnClick(){
		FindObjectOfType<AudioManager>().PlaySound("Eating"); //play the eating sound

		PlayerData.LIFE.Instance.Hunger += hungerPoints;
		PlayerData.LIFE.Instance.Energy += energyPoints;

		PlayerData.Instance.RemoveItem(this);
	}
}