using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : ItemMono{

	public ItemInfo ItemName;//道具數據
	
	private void Awake(){
		GetComponent<MeshRenderer>().material = ItemName.M;//通過道具數據改變自身外形
	}

	public override void OnClick(){ //當玩家點擊物件
		PlayerData.Instance.AddItem(ItemName.GetData); //給玩家背包填入新的道具
		Destroy(gameObject); 
	}
	
}
