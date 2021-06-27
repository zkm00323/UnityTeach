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
    public void Setup(ItemData data){
        ItemName.text = data.Info.Name;
        ItemCount.text = "["+data.Count+"]";
        ItemColor.color = data.Info.ItemColor;

        Data = data;
    }
    

    /*public void OnPointerEnter(PointerEventData eventData)
    {
        SelectionOutline.SetActive(true)

    }
    public void OnPointerClick()
      {Selecting = this;
        Info.OnClick(); 
        UICtrl.Instance.Desc.text=Info.Desc; }
    public void onPointerExit()
    { */
    
      


    public void B_OnClick()
    { //change to OnPointerEnter?
        if (Selecting != null) Selecting.UnSelect();
        UICtrl.Instance.Desc.text = Data.Info.Desc;
        SelectionOutline.SetActive(true);
        Selecting = this;
        Data.Info.OnClick();
    }

    public void UnSelect()
    {
        SelectionOutline.SetActive(false);
        UICtrl.Instance.Desc.text = "";
    }
    
}
