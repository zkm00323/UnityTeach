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
				ItemUICtrl.Selecting.UnSelect();
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
	public void PopupInfoSetup(PopupInfoData data){
		PopupInfoDesc.text = data.Desc;
		PopupInfoTrueText.text = data.TrueText;
		PopupInfoFalseText.text = data.FalseText;
		
		PopupInfoTrueButton.onClick.AddListener(()=> {
			data.TrueAction.Invoke();
			PopupInfoZoomer.ZoomOut();
		});
		
		PopupInfoFalseButton.onClick.AddListener(()=> {
			data.FalseAction.Invoke();
			PopupInfoZoomer.ZoomOut();
		});
		
		PopupInfoZoomer.ZoomIn();
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

