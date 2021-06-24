using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MySO/ItemInfo")]
public class ItemInfo : ScriptableObject{//道具相關所有數據
    
    //數據面
    public int ID;
    public string Name;
    public string Desc;
    public string Price;
    
    //顯示面
    public Color ItemColor;
    public Material M;
    
    public virtual void OnClick(){
    }

    public ItemDate GetDate => new ItemDate(this);
}

public class ItemDate{
    public ItemInfo Info;
    public int Count = 1;

    public ItemDate(ItemInfo info){
        Debug.Log("!!!"+Count);
        Info = info;
    }
}


