using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUICtrl : MonoBehaviour{
    
    public Text ItemName;
    public Image ItemColor;
    
    public void Setup(ItemInfo info){
        ItemName.text = info.Name;
        ItemColor.color = info.ItemColor;
    }
}
