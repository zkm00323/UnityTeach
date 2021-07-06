using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class INTROCTRL : MonoBehaviour {
    private void Start(){
        SceneManager.LoadSceneAsync(Define.Scene.MAIN_SCENE, LoadSceneMode.Additive);
        DontDestroyOnLoad(gameObject);
    }
}
