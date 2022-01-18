using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacement : MonoBehaviour
{
    
    private Vector3 mOffset;
    private float mZCoord;

    //Instantiate()
    //disable view from player's inventory

    #region Dragging furnitures to place
    private void OnMouseDown() {
        if (FindObjectOfType<HouseUICtrl>())
        {
            if (FindObjectOfType<HouseUICtrl>().isDecoreting)
            {
                if (!GetComponent<SitOn>().OnClick)
                {
                    mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
                    mOffset = gameObject.transform.position - GetMouseWorldPos();
                }
            }            
        }        
    }
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);

    }
    private void OnMouseDrag()
    {
        if (FindObjectOfType<HouseUICtrl>())
        {
            if (FindObjectOfType<HouseUICtrl>().isDecoreting)
            {
                if (!GetComponent<SitOn>().OnClick)
                {
                    transform.position = GetMouseWorldPos() + mOffset;
                    GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        }
    }

    private void OnMouseUp()
    {
        GetComponent<Rigidbody>().isKinematic = false;
    }
    #endregion
}
