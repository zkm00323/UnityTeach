using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MySO/HygieneItemInfo")]

public class HygieneItemInfoSO : ItemInfoSO
{
    public int hygienePoints;

	public override void OnClick()
	{
		PlayerData.Instance.Hygiene += hygienePoints;
		//PlayerData.Instance.RemoveItem(this);
	}
}