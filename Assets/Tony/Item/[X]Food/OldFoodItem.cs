using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldFoodItem : ItemMono{

	//public int healthPoints;
	public int hungerPoints;
	public ItemInfoSO Info;
			
	public override void OnClick(){
		UICtrl.Instance.PopupInfoSetup(new PopupInfoData("吃下或放进背包","背包","吃",
			() => {
				PlayerData.Instance.AddItem(Info.GetData);
			},
			() => {
				PlayerData.LIFE.Instance.Hunger += hungerPoints;
			}
		));
		Destroy(gameObject);
	}

	private void Awake(){
		AwakeColorChange();
	}
	
	#region ColorChange
	public Material _m;

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
