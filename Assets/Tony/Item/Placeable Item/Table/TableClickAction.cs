using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableClickAction : ItemMono
{
    
    public int hygienePoints = 100;
    
    public override void OnClick()
    {
        PlayerData.LIFE.Instance.Hygiene += hygienePoints;
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
