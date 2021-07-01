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
    public Image ItemColor;
    public GameObject SelectionOutline;

    private ItemData Data;
    public void Setup(ItemData data, Action onClick){//setupUI數據的同時,傳入onClick方法,讓下面 B_OnClick執行
        ItemName.text = data.Info.Name;
        ItemCount.text = "["+data.Count+"]";
        ItemColor.color = data.Info.ItemColor;

        Data = data;
        OnClick = onClick;
    }
    

    /*public void OnPointerEnter(PointerEventData eventData)
     
             if (Selecting != null) Selecting.UnSelect();
        UICtrl.Instance.Desc.text = Data.Info.Desc;
        SelectionOutline.SetActive(true);
        Selecting = this;
        Data.Info.OnClick();
        
    {
        SelectionOutline.SetActive(true)

    }
    public void OnPointerClick()
      {Selecting = this;
        Info.OnClick(); 
        UICtrl.Instance.Desc.text=Info.Desc; }
    public void onPointerExit()
    { */


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
