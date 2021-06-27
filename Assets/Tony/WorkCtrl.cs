using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkCtrl : MonoBehaviour{
    public WorkWindowUICtrl UI;
    public WorkInfoSO Info;
    private void Update(){
        UpdateUI();
    }
    
    #region UI
    public KeyCode ShopKey;
	
    public Zoomer Zoomer;

    private void UpdateUI(){
        if(Input.GetKeyDown(ShopKey)){ 
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
