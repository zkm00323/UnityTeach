using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenItemCounter : MonoBehaviour{

	public GameObject GenObj;
	public Transform PosTrans;
	public float RefreshGameSce = 60;

	private GameObject LastObj;
	private void Start(){
		GameTimeManager.RegisterTimeAciton(RefreshGameSce,OnTimeChange);
	}
	private void OnTimeChange(){
		Gen();
	}

	void Gen(){
		if(LastObj == null){
			LastObj = Instantiate(GenObj, PosTrans.position, PosTrans.rotation);
		}
	}
}
