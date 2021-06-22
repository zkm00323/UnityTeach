using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUICtrl : MonoBehaviour{

    public static ItemUICtrl Selecting = null;
    
    public Text ItemName;
    public Image ItemColor;
    public GameObject Select;

    private ItemInfo Info;
    public void Setup(ItemInfo info){
        ItemName.text = info.Name;
        ItemColor.color = info.ItemColor;

        Info = info;
    }
    
    public void B_OnClick(){
        if(Selecting != null) Selecting.UnSelect();
        UICtrl.Instance.Desc.text = Info.Desc;
        Select.SetActive(true);
        Selecting = this;
        Info.OnClick();
    }

    public void UnSelect(){
        Select.SetActive(false);
        UICtrl.Instance.Desc.text = "";
    }
    
}
