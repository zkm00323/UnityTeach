using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenItemInScene : MonoBehaviour{

	public GameObject GenObj;
	public Transform PosTrans;
	public float RefreshGameSec = 60; //60 sec in game = 1 sec in real life

	private static GameObject LastObj;
	
	public static GameObject _GenObj;
	public static Transform _PosTrans;

	private void Awake() {
		_GenObj = GenObj;
		_PosTrans = PosTrans;
	}

	private void Start(){
		GameTimeManager.RegisterTimeAciton(RefreshGameSec*60, OnTimeChange); //60 minutes in game gen an new item
		Gen();
	}
	private void OnTimeChange(){
		Gen();
	}

	void Gen(){
		if(LastObj == null){
			LastObj = Instantiate(_GenObj, _PosTrans.position, _PosTrans.rotation);
		}
	}
	
}
