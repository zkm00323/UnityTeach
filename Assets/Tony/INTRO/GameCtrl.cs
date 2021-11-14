using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCtrl : MonoBehaviour {
    public static GameCtrl Instance;

    private void Awake(){
        if (Instance == null){
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
    }

    private void Start(){
        SceneCtrl.Instance.ChangeScene(SceneNameDefine.Scene.MAIN_SCENE);
    }

    //manage scene transition

    private string _previousSceneName;
    public void EnterDoor(string previousScenename, string newSceneName)
    {
        _previousSceneName = previousScenename;
        StartCoroutine(WaitForSceneLoad(newSceneName));
    }

    IEnumerator WaitForSceneLoad(string scenename)
    {
        while (SceneManager.GetActiveScene().name != scenename)
        {
            yield return null;
        }

    }
}
