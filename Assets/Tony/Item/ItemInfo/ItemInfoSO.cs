using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(menuName = "MySO/ItemInfo")]
public class ItemInfoSO : ScriptableObject //道具相關所有數據
{
    
    //數據面
    public int ID;
    public string Name;
    public string Desc;
    public int Price;
    
    //顯示面
    public Sprite ItemImage;
    public Material M;
    public GameObject Prefeb;
    
    public virtual void OnClick(){
    }

    public ItemData GetGetData()
    {
        return new ItemData(this);
    }
}

public class ItemData{
    public ItemInfoSO Info;
    public int Count = 1;

    public ItemData(ItemInfoSO info){ //constructor of class ItemData (for other classes to access info
        Info = info;
    }
}


