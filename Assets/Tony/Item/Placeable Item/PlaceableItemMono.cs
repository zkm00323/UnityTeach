using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlaceableItemMono : ItemMono
{
	public int hygienePoints;
	public ItemInfoSO Info;

	public override void OnClick()
	{
		PlayerData.LIFE.Instance.Hygiene += hygienePoints;
	}


	private void Awake()
	{
		AwakeColorChange();
		Debug.Log("Clicked!");
	}
	#region ColorChange
	public Material defaultColor;
	public Material highlight;

	private void AwakeColorChange()
	{
		defaultColor = GetComponent<MeshRenderer>().material;
	}

	#endregion

	public override void OnPointerEnter()
	{
		GetComponent<MeshRenderer>().material = highlight;
		Debug.Log("Table!");
	}

	public override void OnPointerExit()
	{
		GetComponent<MeshRenderer>().material = defaultColor;
	}


}
