using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UICtrl : MonoBehaviour //attach to canvas on introscene 
{
	public static UICtrl Instance;






	[Header("Craft")]
	public CraftingWindow CraftingCtrl;
	public void Button_CraftWindow() //allows to open on UI
	{
		CraftingCtrl.OpenCraftWindow();
	}



	public void Button_OpenQuestWindow()
	{
		Debug.Log("Y");
	}


	[Header("Health Stats")]
	public CustomBarUICtrl HealthBar;
	public CustomBarUICtrl HungerBar;
	public CustomBarUICtrl HygieneBar;
	public CustomBarUICtrl EnergyBar;

	public KeyCode InventoryKey;
	private void Awake() {
		Instance = this;
	}

	private void Update() {
		UpdateInventory();
		DisplaySkillsUI();
		//CraftingCtrl.DoUpdate();
	}

	[Header("Skill Stats")]

	#region PlayerSkills
	public PlayerSkillsUI skillsUI;
	public Zoomer SkillZoomer;
	public KeyCode SkillsKey; //C




	public void DisplaySkillsUI() //DOES NOT WORK
	{
		//skillsUI.SetUp();

		if (Input.GetKeyDown(SkillsKey))
		{
			if (SkillZoomer.gameObject.activeSelf)
			{
				SkillZoomer.ZoomOut();

			}
			else
			{
				//skillUI.SetUp(new WorkData(Info, 0, 0));
				SkillZoomer.ZoomIn();
				skillsUI.SetUp();
			}
		}
	}

	public void Button_DisplaySkill()
	{
		if (SkillZoomer.gameObject.activeSelf)
		{
			SkillZoomer.ZoomOut();

		}
		else
		{
			//skillUI.SetUp(new WorkData(Info, 0, 0));
			SkillZoomer.ZoomIn();
			skillsUI.SetUp();
		}

	}
	#endregion

	[Header("Inventory")]

	#region Inventory

	public Zoomer Inventory;
	public GameObject descriptionPanel;
	public GameObject ItemUI_O;
	public Transform Bag_T;
	public TextMeshProUGUI Desc;
	private void UpdateInventory() {
		if (Input.GetKeyDown(InventoryKey)) { //Input開關背包UI
			if (Inventory.gameObject.activeSelf) {
				Inventory.ZoomOut();
				if (ItemUICtrl.Selecting != null)
					ItemUICtrl.Selecting.UnSelect();
			}
			else {
				Inventory.ZoomIn();
			}
		}
	}

	public void Button_Inventory() //allows you to open/close inventory on UI
	{
		if (Inventory.gameObject.activeSelf)
		{
			Inventory.ZoomOut();
			if (ItemUICtrl.Selecting != null)
				ItemUICtrl.Selecting.UnSelect();
		}
		else
		{
			Inventory.ZoomIn();
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
				//set item zoom in box to default false and turn it active when mouse hover over it


				//Instance.Desc.text = data.Info.Desc;
				ctrl.SelectionOutline.SetActive(true);
				ItemUICtrl.Selecting = ctrl;

				

				//active the zoom in box when mouse hover over--> tap again to eat it
				data.Info.OnClick();
			});
			ItemUIList.Add(o); //add the item into the UI display
		}

		//Desc.text = "";
	}

	#endregion

	[Header("House Decorating UI")]

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

	[Header("Work")]

	#region Work

	public WorkWindowUICtrl UI;
	public Zoomer WorkZoomer;
	public void StartWork(WorkInfoSO jobSO) {
		UI.Setup(jobSO.GetGetData());
	}
	
	public void ConfirmWork(WorkData data,double workHour) {
		RankInfo info = data.Info.RankList[data.RankIndex];
		data.TotalWorkHour += (float)workHour;
		print(info.Salary);
		print(workHour);
		MoneyUI.playerMoney.AddMoney((int)Math.Floor( info.Salary*(workHour+1)));
		PlayerData.LIFE.Instance.Hunger -= info.HungryCost *(float)workHour;
		PlayerData.LIFE.Instance.Hygiene -= info.HygieneCost *(float)workHour;
		PlayerData.LIFE.Instance.Energy -= info.EnergyCost * (float)workHour;
		
		PlayerData.Skills.Instance.peopleSkillPoint += (int)(info.peopleSkillUp * workHour); //work Hour to int??????
		PlayerData.Skills.Instance.brainPowerPoint += (int)(info.brainPowerUp * workHour);
		PlayerData.Skills.Instance.staminaPoint += info.staminaUp;
		PlayerData.Skills.Instance.charismaPoint += info.charismaUp;
		PlayerData.Skills.Instance.cookingSkillPoint += info.cookingSkillUp;
		
		GameTimeManager.AddTime(workHour + 1);
		
		Debug.Log(GameTimeManager.Time.AddHours(workHour+1));

		UI.B_Exit();

	}

	#endregion

	[Header("Shop")]

	#region SHOP

	public GameObject ShopProductUI_O;
	public Transform Shop_T;

	public Zoomer SHOPZoomer;


	private List<GameObject> ShopProductList;
	public void OPNESHOP(List<ItemInfoSO> shopProductList)
	{
		ShopProductList = new List<GameObject>();
		foreach (var info in shopProductList)
		{  //再讀取ItemList生成新的ItemUI
			var shopItem = Instantiate(ShopProductUI_O, Shop_T);
			shopItem.GetComponent<ShopProductUICtrl>().Setup(info);
			ShopProductList.Add(shopItem);
		}

		if (SHOPZoomer.gameObject.activeSelf)
		{
			SHOPZoomer.ZoomOut();
			if (ItemUICtrl.Selecting != null)
				ItemUICtrl.Selecting.UnSelect();
		}
		else
		{
			SHOPZoomer.ZoomIn();
		}
	}

	public void BUTTON_LeaveShop() //close shop panel
	{
		if (SHOPZoomer.gameObject.activeSelf){
			
			foreach (var o in ShopProductList) {
				Destroy(o);
			}
			SHOPZoomer.ZoomOut();
			if (ItemUICtrl.Selecting != null)
				ItemUICtrl.Selecting.UnSelect();
		}
	}

	public void PlayerBuy(ItemInfoSO info){
		if (MoneyUI.playerMoney.SubtractMoney(info.Price)){
			PlayerData.Instance.AddItem(info.GetGetData());
			Instance.PopupInfoSetup(new PopupInfoData("購買 " + info.Name + " 成功!", "好的", "關閉", () => { }, () => { }));
		}
		else{
			Instance.PopupInfoSetup(new PopupInfoData("你沒有足夠的金錢購買 " + info.Name, "好的", "關閉", () => { }, () => { }));
		}
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

	public PopupInfoData(string desc)
    {
		Desc = desc;
    }


}

