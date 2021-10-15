using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopProductUICtrl : MonoBehaviour{
    public Text Name;
    public Image Color;
    public Text Cost;
    //public Button Buy;
    

    private ItemInfoSO Info;
    public void Setup(ItemInfoSO info){
        Info = info;
        Name.text = info.Name;
        Color.color = info.ItemImage.color;
        Cost.text = info.Price+"";
    }

    //Check purchaseable

    public void Buy_Button(){
        UICtrl.Instance.PlayerBuy(Info);

    }
}
