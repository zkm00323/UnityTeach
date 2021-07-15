using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopCtrl : MonoBehaviour, IPointerClickHandler{

	#region Unity

	[SerializeField]
	private List<ItemInfoSO> ShopProductList;//商店數據存放點

	public void OnPointerClick(PointerEventData pointerEventData){
		//if within a certain time frame 
		UICtrl.Instance.OPNESHOP(ShopProductList);
	}

	private void Awake(){
		//AwakeData();
	}

    private void Update()
    {
		
	}

	#endregion

	#region Data
	/*
	public GameObject ShopProductUI_O;
	public Transform Shop_T;
	
	
	
	[SerializeField]
	private List<ItemInfoSO> ShopProductList;//商店數據存放點

	void AwakeData(){
		foreach(var info in ShopProductList){  //再讀取ItemList生成新的ItemUI
			var shopItem = Instantiate(ShopProductUI_O, Shop_T);
			shopItem.GetComponent<ShopProductUICtrl>().Setup(info);
		}
	}
	public void PlayerBuy(ItemInfoSO info){
		if (MoneyUI.playerMoney.SubtractMoney(info.Price)){
			PlayerData.Instance.AddItem(info.GetData);
			UICtrl.Instance.PopupInfoSetup(new PopupInfoData("購買 "+info.Name+" 成功!","好的","關閉", () => { },() => { }));
		}
		else{
			UICtrl.Instance.PopupInfoSetup(new PopupInfoData("你沒有足夠的金錢購買 "+info.Name,"好的","關閉", () => { },() => { }));
		}
		
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
	*/
	#endregion
	
	#region UI
	//public KeyCode ShopKey;
	
	//public Zoomer Zoomer;
	//public Button leaveButton;

	/*private void UpdateUI(){ //改成遇到npc彈出商店??? 
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
	}*/

	

	/*
	public void LeaveShop() //close shop panel
    {
		if (Zoomer.gameObject.activeSelf)
		{
			Zoomer.ZoomOut();
			if (ItemUICtrl.Selecting != null)
				ItemUICtrl.Selecting.UnSelect();
		}
	}
	*/



/*private void OnTriggerEnter(Collider other)
    {
        if (other.tag== "Player")
        {
            SceneManager.LoadScene("Shop Scene");
        }
    }*/	
	#endregion
}
