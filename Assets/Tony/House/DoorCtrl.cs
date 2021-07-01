using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorCtrl : MonoBehaviour{

    public GameObject[] ActiveObjects;

    private void OnTriggerEnter(Collider other){
        foreach(var o in ActiveObjects){
            o.SetActive(false);
        }
        SceneManager.LoadSceneAsync(Define.Scene.HOUSE_SCENE, LoadSceneMode.Additive);
    }
    
}
