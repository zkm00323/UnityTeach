using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSelectItem : PickUpItem
{
	public override void OnClick(){
		UICtrl.Instance.PopupInfoSetup(new PopupInfoData("吃下或放进背包","背包","吃",
			() => {
				PlayerData.Instance.AddItem(Info);
			},
			() => {
				Info.OnClick();
			}
		));
		Destroy(gameObject);
	}
}
