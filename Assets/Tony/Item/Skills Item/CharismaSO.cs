using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharismaSO : ItemInfoSO
{
    public int charisma;
	public override void OnClick()
	{
		PlayerData.Skills.Instance.charismaPoint += charisma;
		//PlayerData.Instance.RemoveItem(this);
	}
}

