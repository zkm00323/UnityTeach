using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HygieneItemMono : ItemMono
{
    public int hygienePoints;
    public ItemInfoSO Info;

    public override void OnClick()
    {
        PlayerData.Instance.Hygiene += hygienePoints;
    }

	private void Awake()
	{
		AwakeColorChange();
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
	}

	public override void OnPointerExit()
	{
		GetComponent<MeshRenderer>().material = defaultColor;
	}

}
