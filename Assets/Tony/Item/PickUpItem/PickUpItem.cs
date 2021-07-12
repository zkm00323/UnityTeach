using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : ItemMono{

	public static List<PickUpItem> AllItemInScene;
	
	public ItemInfoSO ItemName;//道具數據
	
	private void Awake(){
		AwakeColorChange(); ;//通過道具數據改變自身外形
		AwakeSetData();

	}

	public override void OnClick(){ //當玩家點擊物件
		PlayerData.Instance.AddItem(ItemName.GetData); //給玩家背包填入新的道具
		Destroy(gameObject); 
		AllItemInScene.Remove(this);
	}

	#region Data

	private void AwakeSetData(){
		if(AllItemInScene == null) AllItemInScene = new List<PickUpItem>();
		AllItemInScene.Add(this);
	}

	public ItemSaveData GetSaveData(){
		var saveDate = new ItemSaveData();
		saveDate.Pos = transform.position;
		saveDate.Rot = transform.eulerAngles;
		saveDate.Item = ItemName;
		return saveDate;
	}

	
	public static void Gen(ItemSaveData saveData){
		var o = GameObject.Instantiate(saveData.Item.Prefeb, saveData.Pos, Quaternion.Euler(saveData.Rot));
	}

	#endregion

	#region ColorChange
	
	private void AwakeColorChange() //see ItemMono for material variables
	{
		_originalMaterial = GetComponent<MeshRenderer>().material;
	}

	#endregion

	public override void OnPointerEnter()
	{
		/*GetComponent<MeshRenderer>().material = _m2;*/
		GetComponent<MeshRenderer>().material = _highlightMaterial;
		//_m.SetColor("_BaseColor", Color.green);
	}

	public override void OnPointerExit()
	{
		/*GetComponent<MeshRenderer>().material = _m1;*/
		//_m.SetColor("_BaseColor", Color.white);
		GetComponent<MeshRenderer>().material = _originalMaterial;
	}
}
