using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorCtrl : MonoBehaviour{

    private static DoorCtrl ActiveDoor;
    public GameObject[] ActiveObjects;
    public HouseSO Info;
    private void OnTriggerEnter(Collider other){
        if(Info.PlayerLivesHere){
            Enter();
            return;
        }
        UICtrl.Instance.PopupInfoSetup(new PopupInfoData($"Rent:{Info.Rent}\n SocialScoreNeeded:{Info.SocialScoreNeeded}","租房","取消",
            () => {
                if(PlayerMoney.playerMoney.money < Info.Rent)
                    UICtrl.Instance.PopupInfoSetup(new PopupInfoData($"沒有足夠的錢承租", "確認", () => { OnLeave();}));
                else
                    UICtrl.Instance.PopupInfoSetup(new PopupInfoData($"承租成功!", "確認", () => {
                        
                        Info.PlayerLivesHere = true;
                        Info.LastRentTime = GameTimeManager.Time;
                        GameTimeManager.OnTimeChanged += RentForMonth;
                        PlayerMoney.playerMoney.SubtractMoney(Info.Rent);
                    }));
            },
            () => {
               
            }
        ));
    }

    void RentForMonth(DateTime data){
        if((GameTimeManager.Time-Info.LastRentTime).Minutes>10){
            UICtrl.Instance.PopupInfoSetup(new PopupInfoData($"付租金![{Info.Rent}]", "確認","取消", OnPay,OnLeave));
        }
        
    }

    void OnPay(){
        if(PlayerMoney.playerMoney.money < Info.Rent)
            UICtrl.Instance.PopupInfoSetup(new PopupInfoData($"沒有足夠的錢承租", "確認", OnLeave));
        else{
            Info.PlayerLivesHere = true;
            Info.LastRentTime = GameTimeManager.Time;
            PlayerMoney.playerMoney.SubtractMoney(Info.Rent);
            UICtrl.Instance.PopupInfoSetup(new PopupInfoData($"承租成功!", "確認", () => {}));
        }

    }

    void OnLeave(){
        GameTimeManager.OnTimeChanged -= RentForMonth;
        Info.PlayerLivesHere = false;
        UICtrl.Instance.PopupInfoSetup(new PopupInfoData($"您以結束承租此房!", "確認", () => { }));
    }
    
    void Enter(){
        foreach(var o in ActiveObjects){
            o.SetActive(false);
        }
        
        SceneManager.LoadSceneAsync(Define.Scene.HOUSE_SCENE, LoadSceneMode.Additive);
        ActiveDoor = this;
    }

    public static void Exit(){
        foreach(var o in ActiveDoor.ActiveObjects){
            o.SetActive(true);
        }

        SceneManager.UnloadSceneAsync(Define.Scene.HOUSE_SCENE);
    }
}
