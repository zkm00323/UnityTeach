using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class WorkCtrl : MonoBehaviour, IPointerClickHandler{
    public WorkWindowUICtrl UI;
    public WorkInfoSO JobSO;
    public PlayerSkillsCtrl playerSkills;
    
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

    public void CloseWorkWindow()
    {
        if (Zoomer.gameObject.activeSelf)
        {
            Zoomer.ZoomOut();
            if (ItemUICtrl.Selecting != null)
                ItemUICtrl.Selecting.UnSelect();
        }
    }

    #endregion

    public void GetSalary(WorkData data,double workHour){
        RankInfo info = data.Info.RankList[data.RankIndex];
        data.TotalWorkHour += (float)workHour;
        print(info.Salary);
         print(workHour);
        PlayerMoney.playerMoney.AddMoney((int)Math.Floor( info.Salary*(workHour+1)));
        PlayerData.Instance.Hunger -= info.HungryCost *(float)workHour;
        PlayerData.Instance.Hygiene -= info.HygieneCost *(float)workHour;
        //todo Energy
    }

    
    public void ImpactOnSkillPoints(WorkData data, double workHour) //data from workSO 
    {
        RankInfo info = data.Info.RankList[data.RankIndex];
        playerSkills = FindObjectOfType<PlayerSkillsCtrl>();
        playerSkills.peopleSkillPoint += info.peopleSkillUp * (int)workHour; //work Hour to int??????
        playerSkills.brainPowerPoint += info.brainPowerUp * (int) workHour;
        playerSkills.staminaPoint += info.staminaUp;
        playerSkills.charismaPoint += info.charismaUp;
        playerSkills.cookingSkillPoint += info.cookingSkillUp;
    }
}
