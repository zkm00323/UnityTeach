using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemUICtrl : MonoBehaviour /*,IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler*/
{

    public static ItemUICtrl Selecting = null;
    
    public Text ItemName;
    public Text ItemCount;
    public Image ItemImage;
    public GameObject SelectionOutline;

    private ItemData Data;
    public void Setup(ItemData data, Action onClick){//setupUI數據的同時,傳入onClick方法,讓下面 B_OnClick執行
        ItemName.text = data.Info.Name;
        ItemCount.text = "["+data.Count+"]";
        ItemImage.sprite = data.Info.ItemImage.sprite;

        Data = data;
        OnClick = onClick;
    }
    



    private Action OnClick;
    public void B_OnClick(){
        OnClick.Invoke();
    }

    public void UnSelect()
    {
        SelectionOutline.SetActive(false);
        UICtrl.Instance.Desc.text = "";
    }
    
}
