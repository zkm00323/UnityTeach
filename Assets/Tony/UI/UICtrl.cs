using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICtrl : MonoBehaviour
{
	public static UICtrl Instance;

	public CustomBarUICtrl HealthBar;
	public CustomBarUICtrl HungerBar;
	public CustomBarUICtrl HygieneBar;

	public KeyCode InventoryKey;
	private void Awake(){
		Instance = this;
	}

	private void Update(){
		UpdateInventory();

	}

	#region Inventory

	public Zoomer Inventory;
	public GameObject ItemUI_O;
	public Transform Bag_T;
	private void UpdateInventory(){
		if(Input.GetKeyDown(InventoryKey)){ //Input開關背包UI
			if(Inventory.gameObject.activeSelf){
				Inventory.ZoomOut();
			}
			else{
				Inventory.ZoomIn();
			}
		}
	}

	public List<GameObject> ItemUIList = new List<GameObject>();//生成的ItemUI記錄在這
	public void UpDateBagItem(List<ItemInfo> ItemList){
		foreach(var o in ItemUIList){  //先刪除原本生成的ItemUI
			Destroy(o);
		}
		
		foreach(var info in ItemList){  //再讀取ItemList生成新的ItemUI
			var o = Instantiate(ItemUI_O, Bag_T);
			o.GetComponent<ItemUICtrl>().Setup(info);
			ItemUIList.Add(o);
		}
	}

	#endregion
		
}

