using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseDoorTrigger : MonoBehaviour
{


    public GameObject door;
    private void OnTriggerEnter(Collider other)
    {
        //print(other.name);
        if(other.gameObject.tag.Equals("Player"))HouseDoorCtrl.Exit();

        //or put the following and specify the scene name
        //SceneCtrl.Instance.ChangeScene(SceneNameDefine.Scene.MAIN_SCENE);


    }
}
