using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemUICtrl : MonoBehaviour /*,IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler*/
{

    public static ItemUICtrl Selecting = null;
    
    public Text ItemName;
    public Image ItemColor;
    public GameObject SelectionOutline;

    private ItemInfo Info;
    public void Setup(ItemInfo info){
        ItemName.text = info.Name;
        ItemColor.color = info.ItemColor;

        Info = info;
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
        UICtrl.Instance.Desc.text = Info.Desc;
        SelectionOutline.SetActive(true);
        Selecting = this;
        Info.OnClick();
    }

    public void UnSelect()
    {
        SelectionOutline.SetActive(false);
        UICtrl.Instance.Desc.text = "";
    }
    
}
