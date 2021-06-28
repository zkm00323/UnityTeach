using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : ItemMono{

	public ItemInfoSO ItemName;//道具數據
	

	private void Awake(){
		AwakeColorChange(); ;//通過道具數據改變自身外形
	}

	public override void OnClick(){ //當玩家點擊物件
		PlayerData.Instance.AddItem(ItemName.GetData); //給玩家背包填入新的道具
		Destroy(gameObject); 
	}

	

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
