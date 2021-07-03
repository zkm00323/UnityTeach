using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseUICtrl : MonoBehaviour{

	public Transform GenPos;
	public Button Decorate;
	public GameObject panels;
	
	private void Start(){

		panels.gameObject.SetActive(false);

		StartUI();
		
	}

	public void Button_Decorate()
    {
		panels.gameObject.SetActive(true);
		//pause player data// set player to inactive

	}
	void StartUI(){
		UpDatePlaceableItemData();
	}

	void UpDatePlaceableItemData(){
		List<ItemData> placeableItemList = PlayerData.Instance.ItemList.FindAll(x => x.Info is PlaceableItemInfoSO);
		UpDateBagItem(placeableItemList);
	}
	
	public GameObject ItemUI_O;
	public Transform Bag_T;
	public List<GameObject> ItemUIList = new List<GameObject>();//生成的ItemUI記錄在這
	public void UpDateBagItem(List<ItemData> ItemList){
		foreach(var o in ItemUIList){  //先刪除原本生成的ItemUI
			Destroy(o);
		}
		ItemUIList.Clear();
		foreach(var data in ItemList){  //再讀取ItemList生成新的ItemUI
			var o = Instantiate(ItemUI_O, Bag_T);
			var ctrl = o.GetComponent<ItemUICtrl>();
			ctrl.Setup(data, () => {
				Instantiate((data.Info as PlaceableItemInfoSO).Object, GenPos);
				PlayerData.Instance.RemoveItem(data.Info);
				UpDatePlaceableItemData();
			});
			ItemUIList.Add(o);
		}
	}
}
