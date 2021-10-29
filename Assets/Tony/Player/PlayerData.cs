using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerData{

	private static PlayerData _Instance;

	public static PlayerData Instance{
		get{
			if(_Instance == null) _Instance = new PlayerData();
			return _Instance;
		}
	}

	public float money = 1000;

	public class Skills{
		private static Skills _Instance;

		public static Skills Instance{
			get{
				if (_Instance == null) _Instance = new Skills();
				return _Instance;
			}
		}
		public int peopleSkillPoint = 0;
		public int brainPowerPoint = 0;
		public int staminaPoint = 0;
		public int charismaPoint = 0;
		public int cookingSkillPoint = 0;
		public string[] prestigeRank;
		public float socialScore = 0; //can be boosted by quests?
	}

	public class LIFE {
		private static LIFE _Instance;

		public static LIFE Instance
		{
			get
			{
				if (_Instance == null){
					_Instance = new LIFE();
					_Instance.Health = _Instance._maxHealth;
					_Instance.Hunger = _Instance._maxHunger;
					_Instance.Hygiene = _Instance._maxHygiene;
					
					
				}
				return _Instance;
			}
		}

		[SerializeField]
		private float _health;
		[SerializeField]
		private float _maxHealth = 100;
		[SerializeField]
		private float _hunger;
		[SerializeField]
		private float _maxHunger = 100;
		[SerializeField]
		private float _hygiene;
		[SerializeField]
		private float _maxHygiene = 100;
		[SerializeField]
		private float _energy = 100;
		[SerializeField]
		private float _maxEnergy = 100;


		public float Health
		{
			set
			{
				_health = math.clamp(value, 0, _maxHealth);
				UICtrl.Instance.HealthBar.Value = _health / _maxHealth;
			}
			get
			{

				return _health;
			}
		}

		public float Hunger
		{
			set
			{
				_hunger = math.clamp(value, 0, _maxHunger);
				UICtrl.Instance.HungerBar.Value = _hunger / _maxHunger;
			}
			get
			{

				return _hunger;
			}
		}

		public float Hygiene
		{
			set
			{
				_hygiene = math.clamp(value, 0, _maxHygiene);
				UICtrl.Instance.HygieneBar.Value = _hygiene / _maxHygiene;
			}
			get
			{

				return _hygiene;
			}
		}

		public float Energy
		{
			set
			{
				_energy = math.clamp(value, 0, _maxEnergy);
				UICtrl.Instance.EnergyBar.Value = _energy / _maxEnergy;
			}
			get
			{

				return _energy;
			}
		}

	}

	


	private PlayerData(){

		//StartPlaceableInventory();
	}

	public void Update(){
		UpdateHealthDown();
		UpdateHungerDown();
		UpdateHygieneDown();
		UpdateEnergyDown();
	}

	#region HealthDown
	
	[SerializeField]
	private float _healthDownValue = 1;
	public float _healthDownSpeed = 3f;
	void UpdateHealthDown(){
		if (LIFE.Instance.Hunger <= 0 || LIFE.Instance.Hygiene <=0)
		{
			LIFE.Instance.Health -= _healthDownValue * Time.deltaTime * _healthDownSpeed;
		}
	}

	#endregion

	#region HungerDown
	
	private float _hungerDownValue = 1;
	public float _hungerDownSpeed = 3f;
	void UpdateHungerDown()
	{
		LIFE.Instance.Hunger -= _hungerDownValue * Time.deltaTime * _hungerDownSpeed;
	}


	#endregion

	#region HygieneDown
	
	private float _HygieneDownValue = 1;
	public float _HygieneDownSpeed = 3f;
	void UpdateHygieneDown()
	{
		LIFE.Instance.Hygiene -= _HygieneDownValue * Time.deltaTime * _HygieneDownSpeed;
	}


	#endregion

	#region EnergyDown
	private float _EnergyDownValue = 1;
	public float _EnergyDownSpeed = 3f;
	void UpdateEnergyDown()
	{
		//Energy is only down when player is running or working
	}
    #endregion

    #region Inventory

    public List<ItemData> ItemList = new List<ItemData>();//背包數據存放點
	

	public void AddItem(ItemData data){ //添加道具入口
		var index = ItemList.FindIndex(x => x.Info.ID == data.Info.ID);
		if(index==-1){
			ItemList.Add(data);   
		}else{
			ItemList[index].Count += 1;
		}
		//數據添加
		UICtrl.Instance.UpDateBagItem(ItemList);//通知UI刷新畫面
	}

	public void RemoveItem(ItemInfoSO data){
		var index = ItemList.FindIndex(x => x.Info.ID == data.ID);
		if(index==-1){
			Debug.LogWarning("找不到你要刪除的東西(ID):"+data.ID);
			return;
		}
		
		ItemList[index].Count -= 1;
		if(ItemList[index].Count <= 0){//--ItemList[index].Count <= 0
			ItemList.RemoveAt(index);
		}
	
		UICtrl.Instance.UpDateBagItem(ItemList);
	}

	#endregion

	
}
