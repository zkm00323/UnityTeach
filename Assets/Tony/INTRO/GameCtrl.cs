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

        //yield return new WaitForSeconds(0.5f);
        Debug.Log($"{scenename}");
        Debug.Log($"{SceneManager.GetActiveScene().name}");
        while (SceneManager.GetActiveScene().name != scenename) //loop until it sees the scene name changes to the new scene name 
        {
            yield return null;
        }

        Debug.Log($"{SceneManager.GetActiveScene().name}");

        GameObject entrance = GameObject.Find($"from{_previousSceneName}"); //find the object in the scene with the name "fromSCENENAME" 
        Debug.Log($"entrance found {entrance.name}" );
        /*PlayerMovement.Player.GetComponent<CharacterController>()
        .Move(PlayerMovement.Player.transform.position-entrance.transform.position);*/
        
        Debug.Log($"Entrance pos: {entrance.transform.position}");

        PlayerMovement.Player.MoveTo(entrance.transform.position);
        
        /*var player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log($"Player pos: {PlayerMovement.Player.transform.position}");
        // PlayerMovement.Player.transform.position = entrance.transform.position;
        player.transform.position = entrance.transform.position;
        Debug.Log($"Player pos: {PlayerMovement.Player.transform.position}");*/

    }
}
