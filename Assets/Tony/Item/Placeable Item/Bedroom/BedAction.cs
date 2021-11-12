using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedAction : ItemMono
{
    public int energyPoints;

    public override void OnClick()
    {
        PlayerData.LIFE.Instance.Energy += energyPoints;
    }

    public override void OnPointerEnter()
    {
        GetComponent<MeshRenderer>().material = _highlightMaterial;
    }

    public override void OnPointerExit()
    {
        GetComponent<MeshRenderer>().material = _originalMaterial;
    }
}
