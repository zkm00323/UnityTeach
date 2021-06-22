using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MySO/ItemInfo")]
public class ItemInfo : ScriptableObject{//道具相關所有數據
    
    //數據面
    public string Name;
    public string Desc;

    public virtual void OnClick(){
        
    }
    
    //顯示面
    public Color ItemColor;
    public Material M;
}


