using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerData : MonoBehaviour{

	public static PlayerData Instance;

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

	public float Health{
		set{
			_health = math.clamp(value, 0, _maxHealth);
			UICtrl.Instance.HealthBar.Value = _health/_maxHealth;
		}
		get{
			
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

	private void Start(){
		Health = _maxHealth;
		print(Health);

		Hunger = _maxHunger;
		print(Hunger);

		Hygiene = _maxHygiene;
		print(Hygiene);
		
		Instance = this;

		StartInventory();
	}

	private void Update(){
		UpdateHealthDown();
		UpdateHungerDown();
		UpdateHygieneDown();
	}

	#region HealthDown
	
	[SerializeField]
	private float _healthDownValue = 1;
	public float _healthDownSpeed = 3f;
	void UpdateHealthDown(){
		if (Hunger <=0 || Hygiene <=0)
		{
			Health -= _healthDownValue * Time.deltaTime * _healthDownSpeed;
		}
	}

	#endregion

	#region HungerDown
	
	private float _hungerDownValue = 1;
	public float _hungerDownSpeed = 3f;
	void UpdateHungerDown()
	{
		Hunger -= _hungerDownValue * Time.deltaTime * _hungerDownSpeed;
	}


	#endregion

	#region HygieneDown
	
	private float _HygieneDownValue = 1;
	public float _HygieneDownSpeed = 3f;
	void UpdateHygieneDown()
	{
		Hygiene -= _HygieneDownValue * Time.deltaTime * _HygieneDownSpeed;
	}


	#endregion

	#region Inventory

	private List<ItemData> ItemList = new List<ItemData>();//背包數據存放點

	void StartInventory(){
	}

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

	#region PlayerSkills 技能屬性
	public int prestigePoint;
	public int pursuasionSkill;
	public int intelligence;
	public int cookingSkill;
	public int stamina;
	public int agility;
	public int charisma;

    #endregion
}
