using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseUICtrl : MonoBehaviour {

	public static HouseUICtrl INSTANCE;
	public Transform GenPos;
	public Button Decorate;
	public GameObject panels;

	private PlaceableItemType Type = PlaceableItemType.Table;

    private void Awake()
    {
		INSTANCE = this;

	}
    private void Start() {

		panels.gameObject.SetActive(false);

		StartUI();

	}

	public void Button_Decorate()
	{
		panels.gameObject.SetActive(true);
		//pause player data// set player to inactive

	}

    public void Button_Leave()
    {
        HouseDoorCtrl.Exit();
    }

	public void Button_SetType(PlaceableItemType type){
		Type = type;
		UpDatePlaceableItemUI();
	}

	void StartUI() {
		UpDatePlaceableItemData();
		UpDatePlaceableItemUI();
	}

	Dictionary<PlaceableItemType, List<ItemData>> PlaceableTypeDic;
	void UpDatePlaceableItemData() {
		List<ItemData> placeableItemList = PlayerData.Instance.ItemList.FindAll(x => x.Info is PlaceableItemInfoSO);

		PlaceableTypeDic = new Dictionary<PlaceableItemType, List<ItemData>>();
        foreach (var item in placeableItemList){
			var pitem = item.Info as PlaceableItemInfoSO;
            if (!PlaceableTypeDic.ContainsKey(pitem.Type)) {
				PlaceableTypeDic.Add(pitem.Type, new List<ItemData>());
            }
			PlaceableTypeDic[pitem.Type].Add(item);
		}


			
	}

	void UpDatePlaceableItemUI(){
		if (PlaceableTypeDic.ContainsKey(Type)){
			UpDateBagItem(PlaceableTypeDic[Type]);
		}else{
			UpDateBagItem(new List<ItemData>());
		}
	}

	public GameObject ItemUI_O;
	public Transform Bag_T;
	public List<GameObject> ItemUIList = new List<GameObject>();//生成的ItemUI記錄在這
	public void UpDateBagItem(List<ItemData> ItemList) {
		foreach (var o in ItemUIList) {  //先刪除原本生成的ItemUI
			Destroy(o);
		}
		ItemUIList.Clear();
		foreach (var data in ItemList) {  //再讀取ItemList生成新的ItemUI
			var o = Instantiate(ItemUI_O, Bag_T);
			var ctrl = o.GetComponent<ItemUICtrl>();
			ctrl.Setup(data, () => {
				Instantiate((data.Info as PlaceableItemInfoSO).Object, GenPos);
				PlayerData.Instance.RemoveItem(data.Info);
				StartUI();

			});
			ItemUIList.Add(o);
		}
		
	} }

//Each category shows a panel of furnitures it contains
/*public List<GameObject> Tables = new List<GameObject>();
 * public void ShowTables(List<ItemData> ItemList){ 
 * foreach (var o in Tables)
 * {Destroy (o);
 * Tables.Clear();
 * foeach(var data in ItemUIList)
 * { var o = Instantiate(ChairUI_O, Chair_T);
 * var ctrl = o.GetComponent<ItemUICtrol>();
 * ctrl.Setup(data, () => {
 * Instantiate((data.Info as PlaceableItemInfoSO.Table


UpdateChairPanel()
{List<ItemData> TableList = PlayerData.Instance.ItemList.FindAll(x => x.Info is PlaceableItemInfoSO.Table);



*/
