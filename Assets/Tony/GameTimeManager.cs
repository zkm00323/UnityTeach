using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameTimeManager : MonoBehaviour{

    private static GameTimeManager Instance;
    //60 sec in game= 1 sec in REAL LIFE
    public const int TimeScale = 60;
    public const int UpdateRealSec = 1;

    [SerializeField]
    private float TimeSpeed = 1;

    public static DateTime Time{ private set; get; } //prperty of class/struct DateTime

    private void Awake(){
        Instance = this;
    }

    void Start(){
        Time = new DateTime(1,1,1,7,00,0);
        RegisterTimeAciton(GetGameSecFromRealSec(1),TimeCtrl);
    }

    public static float GetGameSecFromRealSec(float sec){
        return sec * TimeScale;
    }

    public static float GetRealSecFromGameSec(float gameSec){
        return gameSec / TimeScale;
    }
    
    void TimeCtrl(){
        Debug.Log(DateTime.Now);
        Time = Time.AddMinutes(1);
    }

    private static Dictionary<Action, Coroutine> TimeRegDic = new Dictionary<Action, Coroutine>();
    public static void RegisterTimeAciton(float spaceGameSec, Action onDo){
        TimeRegDic.Add(onDo, Instance.StartCoroutine(ItemEventCounter(spaceGameSec, onDo)));
    }

    public static void UnRegisterTimeAciton(Action onDo){
        if(!TimeRegDic.ContainsKey(onDo)) return;
        Instance.StopCoroutine(TimeRegDic[onDo]);
        TimeRegDic.Remove(onDo);
    }

    static IEnumerator ItemEventCounter(float spaceGameSec, Action onDo){
        yield return new WaitForSeconds(GetRealSecFromGameSec(spaceGameSec));
        onDo.Invoke();
        yield return ItemEventCounter(spaceGameSec,onDo);
    }
}
