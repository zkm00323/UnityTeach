using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseUICtrl : MonoBehaviour {

	public static HouseUICtrl INSTANCE;
	public Transform DropPoint;
	public Button Decorate;
	public GameObject panels;
	public bool isDecoreting;

	private PlaceableItemType Type = PlaceableItemType.Table;
	public Dictionary<GameObject, GameObject> FurnitureObjDic = new Dictionary<GameObject, GameObject>(); //實體家具和家具數據prefab
	
    private void Awake()
    {
		INSTANCE = this;

	}
    private void Start() {

		panels.gameObject.SetActive(false);

		StartUI();
		StartGen();
	}

	public void Button_Decorate()
	{
		panels.gameObject.SetActive(true);
		isDecoreting = true;
		//pause player data// set player to inactive
	}

	public void Button_Finish()
    {
		panels.gameObject.SetActive(false);
		isDecoreting = false;
	}

    public void Button_Leave()
    {
        HouseDoorCtrl.Exit();
		//allow player to leave house without walking to door
		
		
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
				var obj = Instantiate((data.Info as PlaceableItemInfoSO).Object, DropPoint);
				FurnitureObjDic.Add(obj, (data.Info as PlaceableItemInfoSO).Object);
				PlayerData.Instance.RemoveItem(data.Info); //****Remove this item from player's data (remove it from player's inventory cos now it's in here
				StartUI();

			});
			ItemUIList.Add(o);
		}
		
	} 
	
	private void StartGen(){ //讀取生成實體和prefab
		var data = HouseDoorCtrl.LastInfo.FurnitureList;

		foreach(var i in data){
			var obj = Instantiate(i.Prefeb, i.Pos,Quaternion.Euler(i.Rot));
			FurnitureObjDic.Add(obj, i.Prefeb);
		}
	}
}



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
