using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class WorkCtrl : MonoBehaviour, IPointerClickHandler{
    public WorkWindowUICtrl UI;
    public WorkInfoSO JobSO;
    
    private void Update(){
        
    }
    
    #region UI
    //public KeyCode WorkKey;
	
    public Zoomer Zoomer;

    /*private void UpdateUI(){
        if(Input.GetKeyDown(WorkKey)){ 
            if(Zoomer.gameObject.activeSelf){
                Zoomer.ZoomOut();
                if(ItemUICtrl.Selecting!=null)
                    ItemUICtrl.Selecting.UnSelect();
            }
            else{
                UI.Setup(new WorkData(Info, 0,0));
                Zoomer.ZoomIn();
            }
        }
    }*/
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (Zoomer.gameObject.activeSelf)
        {
            Zoomer.ZoomOut();
            if (ItemUICtrl.Selecting != null)
                ItemUICtrl.Selecting.UnSelect();
        }
        else
        {
            UI.Setup(JobSO.GetData);
            Zoomer.ZoomIn();
        }
    }

    #endregion

    public void GetSalary(WorkData data,double workHour){
        RankInfo info = data.Info.RankList[data.RankIndex];
        data.TotalWorkHour += (float)workHour;
        print(info.Salary);
         print(workHour);
        PlayerMoney.playerMoney.AddMoney((int)Math.Floor( info.Salary*workHour));
        PlayerData.Instance.Hunger -= info.HungryCost;
        PlayerData.Instance.Hygiene -= info.HygieneCost;
        //todo Energy
    }
}
