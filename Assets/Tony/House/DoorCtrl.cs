using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorCtrl : MonoBehaviour{

    private static DoorCtrl ActiveDoor;
    public HouseSO Info;
    private void OnTriggerEnter(Collider other){
        if(Info.PlayerLivesHere){
            Enter();
            return;
        }
        UICtrl.Instance.PopupInfoSetup(new PopupInfoData($"Rent:{Info.Rent}\n SocialScoreNeeded:{Info.SocialScoreNeeded}","租房","取消",
            () => {
                if(PlayerData.Instance.money < Info.Rent)
                    UICtrl.Instance.PopupInfoSetup(new PopupInfoData($"沒有足夠的錢承租", "確認", () => { EndLease();}));
                else
                    UICtrl.Instance.PopupInfoSetup(new PopupInfoData($"承租成功!", "確認", () => {
                        
                        Info.PlayerLivesHere = true;
                        Info.LastRentTime = GameTimeManager.Time;
                        GameTimeManager.OnTimeChanged += RentForMonth;
                        MoneyUI.playerMoney.SubtractMoney(Info.Rent);
                    }));
            },
            () => {
               
            }
        ));
    }

    void RentForMonth(DateTime data){
        if((GameTimeManager.Time-Info.LastRentTime).Minutes>10){
            UICtrl.Instance.PopupInfoSetup(new PopupInfoData($"付租金![{Info.Rent}]", "確認","取消", OnPay, EndLease));
        }
        
    }

    void OnPay(){
        if(PlayerData.Instance.money < Info.Rent)
            UICtrl.Instance.PopupInfoSetup(new PopupInfoData($"沒有足夠的錢承租", "確認", EndLease));
        else{
            Info.PlayerLivesHere = true;
            Info.LastRentTime = GameTimeManager.Time;
            MoneyUI.playerMoney.SubtractMoney(Info.Rent);
            UICtrl.Instance.PopupInfoSetup(new PopupInfoData($"承租成功!", "確認", () => {}));
        }

    }

    void EndLease(){
        GameTimeManager.OnTimeChanged -= RentForMonth;
        Info.PlayerLivesHere = false;
        UICtrl.Instance.PopupInfoSetup(new PopupInfoData($"您以結束承租此房!", "確認", () => { }));
    }
    
    void Enter(){
        SceneCtrl.Instance.ChangeScene(Define.Scene.HOUSE_SCENE);
        ActiveDoor = this;
    }

    public static void Exit(){
        SceneCtrl.Instance.ChangeScene(Define.Scene.MAIN_SCENE);
    }

   
}
