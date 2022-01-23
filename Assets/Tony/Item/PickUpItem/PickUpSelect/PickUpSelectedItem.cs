using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PickUpSelectedItem : PickUpItem
{
	public override void OnClick(){
		UICtrl.Instance.PopupInfoSetup(new PopupInfoData("吃下或放进背包","背包","吃",
			() => {
				PlayerData.Instance.AddItem(ItemName.GetGetData());
			},
			() => {
				ItemName.OnClick();
			}
		));
		Destroy(gameObject); //destroy if player select eating
		AllItemInScene.Remove(this);
	}

	

	#region ColorChange //see ItemMono for material variables

	private void AwakeColorChange()
	{
		_originalMaterial = GetComponent<MeshRenderer>().material;
	}

	#endregion

	public override void OnPointerEnter()
	{
		/*GetComponent<MeshRenderer>().material = _m2;*/
		GetComponent<MeshRenderer>().material = _highlightMaterial;
		//_m.SetColor("_BaseColor", Color.green);
	}

	public override void OnPointerExit()
	{
		/*GetComponent<MeshRenderer>().material = _m1;*/
		//_m.SetColor("_BaseColor", Color.white);
		GetComponent<MeshRenderer>().material = _originalMaterial;
	}
}
