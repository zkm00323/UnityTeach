using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ItemUICtrl : MonoBehaviour
{

    public static ItemUICtrl Selecting = null;
    public bool isMouseOver = false;
    
    public TextMeshProUGUI ItemName;
    public TextMeshProUGUI ItemCount;
    public Image ItemImage;
    public GameObject SelectionOutline;

    private ItemData Data;
    public void Setup(ItemData data, Action onClick){//setupUI數據的同時,傳入onClick方法,讓下面 B_OnClick執行
        ItemName.text = data.Info.Name;
        ItemCount.text = "["+data.Count+"]";
        ItemImage.sprite = data.Info.ItemImage;

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



    public virtual void OnPointerEnter()
    {
        isMouseOver = true;
        FindObjectOfType<UICtrl>().descriptionPanel.SetActive(true); //or just UICtrl.Instance.descriptionPanel
        UICtrl.Instance.Desc.text = Data.Info.Desc;



    }



    public virtual void OnPointerExit()
    {
        isMouseOver = false;
        FindObjectOfType<UICtrl>().descriptionPanel.SetActive(false);
    }
}
