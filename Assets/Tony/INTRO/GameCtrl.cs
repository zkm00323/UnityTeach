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
        SceneManager.LoadSceneAsync(Define.Scene.MAIN_SCENE);
    }
}
