using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class WorkCtrl : MonoBehaviour, IPointerClickHandler{
    
    public WorkInfoSO JobSO;

    public void OnPointerClick(PointerEventData pointerEventData){
        UICtrl.Instance.StartWork(JobSO);
    }
}
