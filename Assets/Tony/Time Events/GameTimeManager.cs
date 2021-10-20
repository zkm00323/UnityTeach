using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.PlayerLoop;

public class GameTimeManager : MonoBehaviour{

    private static GameTimeManager Instance;
    //60 sec in game= 1 sec in REAL LIFE
    public const int TimeScale = 60;
    public const int UpdateRealSec = 1;

    [SerializeField]
    private float TimeSpeed = 1;

    public static DateTime Time{ private set; get; } //prperty of class/struct DateTime
    
    public static void AddTime(double hour){
        Time = Time.AddHours(hour);
        foreach(var dic in TimeRegDic){
            dic.Key.Invoke();
        }
    }
    
    public void Set(){
        
    }
    
    private void Awake(){
        Instance = this;
        Time = new DateTime(1,1,1,7,00,0); //first year, month, day, 7AM 0 seconds
    }
    

    void Start(){
        RegisterTimeAciton(GetGameSec(1),OneMinuteGameTimePassed); //every seconds pass, trigger a specific action: add 1 minute to clock
        //Debug.Log(Time);
    }

    public static float GetGameSec(float sec){
        return sec * TimeScale; //1*60 
    }

    public static float GetRealSecFromGameSec(float gameSec){
        return gameSec / TimeScale;
    }
    
    /*public static float GetGameHourFromRealSec(float sec)
    {
        return 
    }*/
    void OneMinuteGameTimePassed(){
        //Debug.Log(DateTime.Now);
        Time = Time.AddMinutes(1);
        
    }

    void OnWork(WorkData data, double workHour)
    {
        Time = Time.AddHours(workHour);
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
