using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopProductUICtrl : MonoBehaviour{
    public Text Name;
    public Image Color;
    public Text Cost;
    //public Button Buy;

    private ItemInfo Info;
    public void Setup(ItemInfo info){
        Info = info;
        Name.text = info.Name;
        Color.color = info.ItemColor;
        Cost.text = info.Price;
    }

    public void B_Click(){
        PlayerData.Instance.AddItem(Info.GetDate);
    }
}
