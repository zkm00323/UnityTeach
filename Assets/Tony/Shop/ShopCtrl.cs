using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCtrl : MonoBehaviour {

	#region Unity

	private void Awake(){
		AwakeData();
	}

	private void Update(){
		UpdateUI();
	}

	#endregion
	
	

	#region Data

	public GameObject ShopProductUI_O;
	public Transform Shop_T;
	
	[SerializeField]
	private List<ItemInfo> ShopProductList;//商店數據存放點

	void AwakeData(){
		foreach(var info in ShopProductList){  //再讀取ItemList生成新的ItemUI
			var o = Instantiate(ShopProductUI_O, Shop_T);
			o.GetComponent<ShopProductUICtrl>().Setup(info);
		}
	}

	#endregion
	
	#region UI
	public KeyCode ShopKey;
	
	public Zoomer Zoomer;

	
	private void UpdateUI(){
		if(Input.GetKeyDown(ShopKey)){ //Input開關背包UI
			if(Zoomer.gameObject.activeSelf){
				Zoomer.ZoomOut();
				if(ItemUICtrl.Selecting!=null)
					ItemUICtrl.Selecting.UnSelect();
			}
			else{
				Zoomer.ZoomIn();
			}
		}
	}
	
	#endregion
}
