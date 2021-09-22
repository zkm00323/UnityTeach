using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenItemInScene : MonoBehaviour{

	public GameObject GenObj;
	public Transform PosTrans;
	public float RefreshGameSec = 60; //60 sec in game = 1 sec in real life

	private GameObject LastObj;
	private void Start(){
		GameTimeManager.RegisterTimeAciton(RefreshGameSec*60*6,OnTimeChange);
		Gen();
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
