using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : Item{

	//public int healthPoints;
	public int hungerPoints;
	public override void OnClick(){
		PlayerData.Instance.Hunger += hungerPoints;
		Destroy(gameObject);
	}

	private void Awake(){
		AwakeColorChange();
	}
	
	#region ColorChange
	public Material _m;
	public Material _m2;
	public Material _m1;

	private void AwakeColorChange(){
		_m = GetComponent<MeshRenderer>().material;
	}

	#endregion
	
	public override void OnPointerEnter(){
		/*GetComponent<MeshRenderer>().material = _m2;*/
		_m.SetColor("_BaseColor", Color.green);
	}

	public override void OnPointerExit(){
		/*GetComponent<MeshRenderer>().material = _m1;*/
		_m.SetColor("_BaseColor", Color.white);
	}
}
