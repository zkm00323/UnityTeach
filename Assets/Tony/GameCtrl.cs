using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : MonoBehaviour {	
	public static GameCtrl Instance;

	public ShopCtrl Shop;
	public WorkCtrl Work;
	public PlayerSkillsCtrl playerSkill; //not working in inspector???
	private void Awake(){
		Instance = this;
	}


}
