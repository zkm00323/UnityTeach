using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseDoorCtrl : MonoBehaviour{

    private static Vector3 LastExitPos;
    public static HouseSO LastInfo;
    
    public HouseSO Info;
    public Transform ExitPos;

    public string houseScene;

    private void OnApplicationQuit()
    {
        //Info.PlayerLivesHere = false; //reset player's housing state 
    }
    private void OnTriggerEnter(Collider other){
        if(Info.PlayerLivesHere){
            Enter();
            return;
        }
        UICtrl.Instance.PopupInfoSetup(new PopupInfoData($"Rent:{Info.Rent}\n SocialScoreNeeded:{Info.SocialScoreNeeded}","Rent House","Cancel",
            () => {
                if(PlayerData.Instance.money < Info.Rent)
                    UICtrl.Instance.PopupInfoSetup(new PopupInfoData($"You don't have enough to pay rent!!", "Confirm", () => { EndLease();}));
                else
                    UICtrl.Instance.PopupInfoSetup(new PopupInfoData($"Succesful!", "OK", () => {
                        
                        Info.PlayerLivesHere = true;
                        Info.LastRentTime = GameTimeManager.Time;
                        GameTimeManager.RegisterTimeAciton(60*60,RentForMonth);
                        MoneyUI.playerMoney.SubtractMoney(Info.Rent);
                    }));
            },
            () => {
               
            }
        ));
    }

    void RentForMonth(){
        UICtrl.Instance.PopupInfoSetup(new PopupInfoData($"Pay rent![{Info.Rent}]", "Confirm","Cancel", OnPay, EndLease));
    }

    void OnPay(){
        if(PlayerData.Instance.money < Info.Rent)
            UICtrl.Instance.PopupInfoSetup(new PopupInfoData($"Gotta earn more to pay rent", "OK", EndLease));
        else{
            Info.PlayerLivesHere = true;
            Info.LastRentTime = GameTimeManager.Time;
            MoneyUI.playerMoney.SubtractMoney(Info.Rent);
            UICtrl.Instance.PopupInfoSetup(new PopupInfoData($"Success!", "OK", () => {}));
        }

    }

    void EndLease(){
        GameTimeManager.UnRegisterTimeAciton(RentForMonth);
        Info.PlayerLivesHere = false;
        UICtrl.Instance.PopupInfoSetup(new PopupInfoData($"Lease ended!", "OK", () => { }));
    }
    
    void Enter(){
        LastExitPos = ExitPos.position;
        LastInfo = Info;
        SceneCtrl.Instance.ChangeScene(houseScene);
    }

    public static void Exit(){
        FurnitureSave();
        SceneCtrl.Instance.ChangeScene(SceneNameDefine.Scene.MAIN_SCENE);
        PlayerMovement.Player.GetComponent<CharacterController>()
                .Move(LastExitPos-PlayerMovement.Player.transform.position);
    }

    static void FurnitureSave(){ //家具位置擺放存檔
        LastInfo.FurnitureList = new List<FurnitureData>();
        foreach(var i in HouseUICtrl.INSTANCE.FurnitureObjDic){
            LastInfo.FurnitureList.Add(new FurnitureData(i.Key.transform.position, i.Key.transform.eulerAngles, i.Value));
        }
    }
}
