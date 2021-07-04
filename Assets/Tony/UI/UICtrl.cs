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
		//DontDestroyOnLoad(gameObject);


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
	public void UpDateBagItem(List<ItemData> ItemList){
		foreach(var o in ItemUIList){  //先刪除原本生成的ItemUI
			Destroy(o);
		}
		ItemUIList.Clear();
		foreach(var data in ItemList){  //再讀取ItemList生成新的ItemUI
			var o = Instantiate(ItemUI_O, Bag_T);
			var ctrl = o.GetComponent<ItemUICtrl>();
			ctrl.Setup(data, () => {
				if (ItemUICtrl.Selecting != null) ItemUICtrl.Selecting.UnSelect();
				Instance.Desc.text = data.Info.Desc;
				ctrl.SelectionOutline.SetActive(true);
				ItemUICtrl.Selecting = ctrl;
				data.Info.OnClick();
			});
			ItemUIList.Add(o);
		}

		Desc.text = "";
	}

	#endregion

	#region HouseDecoratingUI
	public List<GameObject> PlaceableItemUIList = new List<GameObject>();//生成的ItemUI記錄在這

	public void UpdateHouseStorage(List<ItemData> PlaceableItemList)
    {
			foreach (var o in PlaceableItemUIList)
			{  //先刪除原本生成的ItemUI
				Destroy(o);
			}
			foreach (var info in PlaceableItemList)
        {//if tag== placeable
		 //var o = Instantiate(FurnitureUI_O, Furniture_T);
			//o.GetComponent<ItemUICtrl>().Setup(info);
			//
        }
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

		PopupInfoFalseButton.gameObject.SetActive(!Data.Single);
		
		PopupInfoZoomer.ZoomIn();
	}

	public void TrueAction(){
		PopupInfoZoomer.ZoomOut();
		Data.TrueAction.Invoke();
	}
	
	public void FalseAction(){
		PopupInfoZoomer.ZoomOut();
		Data.FalseAction.Invoke();
	}

	#endregion
}

public class PopupInfoData{
	public string Desc;
	public string TrueText;
	public string FalseText;
	public Action TrueAction;
	public Action FalseAction;
	public bool Single;
	
	public PopupInfoData(string desc,string trueText,string falseText,Action trueAction,Action falseAction){
		Desc = desc;
		TrueText = trueText;
		FalseText = falseText;
		TrueAction = trueAction;
		FalseAction = falseAction;
	}
	
	public PopupInfoData(string desc,string trueText,Action trueAction){
		Desc = desc;
		TrueText = trueText;
		TrueAction = trueAction;
		Single = true;
	}
}

