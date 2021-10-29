using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntelligenceSO : ItemInfoSO
{
    public int brainPower;

	public override void OnClick()
	{
		PlayerData.Skills.Instance.brainPowerPoint += brainPower;
		
	}
}
