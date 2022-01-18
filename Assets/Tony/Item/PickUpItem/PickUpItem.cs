using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : ItemMono{

	public static List<PickUpItem> AllItemInScene; //把場景有的物件加到這個清單裡
	
	public ItemInfoSO ItemName;//道具數據
	
	protected virtual void Awake(){
		AwakeColorChange(); ;//通過道具數據改變自身外形
		AwakeSetData();

	}

	public override void OnClick(){ //當玩家點擊物件
		PlayerData.Instance.AddItem(ItemName.GetGetData()); //給玩家背包填入新的道具
		Destroy(gameObject); 
		AllItemInScene.Remove(this);
		Debug.Log("Item REMOVED from scene!!!");
	}

	#region Data

	private void AwakeSetData(){
		if(AllItemInScene == null) AllItemInScene = new List<PickUpItem>();
		AllItemInScene.Add(this); //把物件個別加進清單(把這個class加到每個要被存取的物件上
		Debug.Log("Item added to pick up item list!!");
	}

	public ItemSaveData GetSaveData(){
		var saveData = new ItemSaveData(); //instantiate a new ItemSaveData class
		saveData.Pos = transform.position;
		saveData.Rot = transform.eulerAngles;
		saveData.Item = ItemName;
		return saveData;
	}

	
	public static void Gen(ItemSaveData saveData){
		var o = GameObject.Instantiate(saveData.Item.Prefeb, saveData.Pos, Quaternion.Euler(saveData.Rot));
	} //instantiate new ItemSaveData class item

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
