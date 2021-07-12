using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PickUpSelectedItem : PickUpItem
{
	public override void OnClick(){
		UICtrl.Instance.PopupInfoSetup(new PopupInfoData("吃下或放进背包","背包","吃",
			() => {
				PlayerData.Instance.AddItem(ItemName.GetData);
			},
			() => {
				ItemName.OnClick();
			}
		));
		Destroy(gameObject);
	}

	private void Awake()
	{
		AwakeColorChange();
	}

    #region Save Objects Scene data
    public void Start()
    {
		GameCtrl_.SaveEvent += SaveFunction;
    }
    public void OnDestroy()
    {
		GameCtrl_.SaveEvent -= SaveFunction;
    }

	public void SaveFunction(object sender, EventArgs args)
    {
		SavedFoodPosition food = new SavedFoodPosition(); //generate a new food item at the same position??
		food.PositionX = transform.position.x;
		food.PositionY = transform.position.y;
		food.PositionZ = transform.position.z;
		GameCtrl_.Instance.GetListForScene().SavedFood.Add(food);

	}
	#endregion

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
