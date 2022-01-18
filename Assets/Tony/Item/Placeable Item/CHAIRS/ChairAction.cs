using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairAction : ItemMono
{
    public int energyPoints;

    public override void OnClick()
    {
        PlayerData.LIFE.Instance.Energy += energyPoints;
    }

    public override void OnPointerEnter()
    {
        GetComponentInChildren<MeshRenderer>().material = _highlightMaterial;
    }

    public override void OnPointerExit()
    {
        GetComponentInChildren<MeshRenderer>().material = _originalMaterial;
    }
}
