using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : MonoBehaviour {	
	public static GameCtrl Instance;

	public ShopCtrl Shop;
	public WorkCtrl Work;
	private void Awake(){
		Instance = this;
	}


}
