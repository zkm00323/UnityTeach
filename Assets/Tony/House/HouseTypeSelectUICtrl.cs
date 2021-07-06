using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseTypeSelectUICtrl : MonoBehaviour
{
    public PlaceableItemType CHANGEType;

    public void BUTTONCLICK(){
        HouseUICtrl.INSTANCE.Button_SetType(CHANGEType);
    }

}
