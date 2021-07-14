using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class WorkCtrl : MonoBehaviour, IPointerClickHandler{
    //public WorkWindowUICtrl UI;
    public WorkInfoSO JobSO;
    //public PlayerSkillsCtrl playerSkills;
    
    private void Update(){
        
    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        UICtrl.Instance.StartWork(JobSO);


    }
    #region UI
    //public KeyCode WorkKey;

    //public Zoomer Zoomer;

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


    public void CloseWorkWindow()
    {
        UICtrl.Instance.ExitWork();
    }

    #endregion

    
    public void GetSalary(WorkData data,double workHour){
        RankInfo info = data.Info.RankList[data.RankIndex];
        data.TotalWorkHour += (float)workHour;
        print(info.Salary);
         print(workHour);
        MoneyUI.playerMoney.AddMoney((int)Math.Floor( info.Salary*(workHour+1)));
        PlayerData.LIFE.Instance.Hunger -= info.HungryCost *(float)workHour;
        PlayerData.LIFE.Instance.Hygiene -= info.HygieneCost *(float)workHour;
        //todo Energy
    }

    
    public void ImpactOnSkillPoints(WorkData data, double workHour) //data from workSO 
    {
        RankInfo info = data.Info.RankList[data.RankIndex];
        //playerSkills = FindObjectOfType<PlayerSkillsCtrl>();
        PlayerData.Skills.Instance.peopleSkillPoint += (int)(info.peopleSkillUp * workHour); //work Hour to int??????
        PlayerData.Skills.Instance.brainPowerPoint += (int)(info.brainPowerUp * workHour);
        PlayerData.Skills.Instance.staminaPoint += info.staminaUp;
        PlayerData.Skills.Instance.charismaPoint += info.charismaUp;
        PlayerData.Skills.Instance.cookingSkillPoint += info.cookingSkillUp;
    }
}
