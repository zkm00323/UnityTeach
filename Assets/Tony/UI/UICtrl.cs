using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
	public Text Desc;
	private void UpdateInventory(){
		if(Input.GetKeyDown(InventoryKey)){ //Input開關背包UI
			if(Inventory.gameObject.activeSelf){
				Inventory.ZoomOut();
				if(ItemUICtrl.Selecting!=null)
					ItemUICtrl.Selecting.UnSelect();
			}
			else{
				Inventory.ZoomIn();
			}
		}
	}

	public List<GameObject> ItemUIList = new List<GameObject>();//生成的ItemUI記錄在這
	public void UpDateBagItem(List<ItemDate> ItemList){
		foreach(var o in ItemUIList){  //先刪除原本生成的ItemUI
			Destroy(o);
		}
		
		foreach(var info in ItemList){  //再讀取ItemList生成新的ItemUI
			var o = Instantiate(ItemUI_O, Bag_T);
			o.GetComponent<ItemUICtrl>().Setup(info);
			ItemUIList.Add(o);
		}

		Desc.text = "";
	}

	#endregion

	#region PopupInfo

	public Zoomer PopupInfoZoomer;
	public Text PopupInfoDesc;
	public Text PopupInfoTrueText;
	public Button PopupInfoTrueButton;
	public Text PopupInfoFalseText;
	public Button PopupInfoFalseButton;

	private PopupInfoData Data;
	public void PopupInfoSetup(PopupInfoData data){
		Data = data;
		PopupInfoDesc.text = data.Desc;
		PopupInfoTrueText.text = data.TrueText;
		PopupInfoFalseText.text = data.FalseText;
		
		PopupInfoTrueButton.onClick.RemoveListener(TrueAction);
		PopupInfoFalseButton.onClick.RemoveListener(FalseAction);
		
		PopupInfoTrueButton.onClick.AddListener(TrueAction);
		PopupInfoFalseButton.onClick.AddListener(FalseAction);
		
		PopupInfoZoomer.ZoomIn();
	}

	public void TrueAction(){
		Data.TrueAction.Invoke();
		PopupInfoZoomer.ZoomOut();
	}
	
	public void FalseAction(){
		Data.FalseAction.Invoke();
		PopupInfoZoomer.ZoomOut();
	}

	#endregion
}

public class PopupInfoData{
	public string Desc;
	public string TrueText;
	public string FalseText;
	public Action TrueAction;
	public Action FalseAction;

	public PopupInfoData(string desc,string trueText,string falseText,Action trueAction,Action falseAction){
		Desc = desc;
		TrueText = trueText;
		FalseText = falseText;
		TrueAction = trueAction;
		FalseAction = falseAction;
	}
}

