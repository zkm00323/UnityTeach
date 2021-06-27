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
        Cost.text = info.Price+"";
    }

    //Check purchaseable

    public void Buy_Button(){
        GameCtrl.Instance.Shop.PlayerBuy(Info);

    }
}
