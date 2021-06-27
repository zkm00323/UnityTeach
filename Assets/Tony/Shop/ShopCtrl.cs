using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCtrl : MonoBehaviour {

	#region Unity
	public static PlayerMoney playerMoney;
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
			var shopItem = Instantiate(ShopProductUI_O, Shop_T);
			shopItem.GetComponent<ShopProductUICtrl>().Setup(info);
		}
	}
	public void CheckWallet()
    {
		foreach(var info in ShopProductList)
        {
			int price = int.Parse(info.Price); //convert price string to int
			if (playerMoney.money >= price)
            {
				Debug.Log("can purchase this item");
				//買下物品
            }
			else
            {
				Debug.Log("Not enough coins!!");
            }
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
