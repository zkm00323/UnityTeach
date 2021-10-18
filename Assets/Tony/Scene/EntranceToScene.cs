using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceToScene : MonoBehaviour
{
    public GameObject entrance;
    private string NameOfScene { get; set; } //name of the scene you want to go to

    public void OnTriggerEnter(Collider other)
    {
        //print(other.name);
        if (other.gameObject.tag.Equals("Player")) 
        SceneCtrl.Instance.ChangeScene(SceneNameDefine.Scene.GhettoStreet); //how to go to 'nameOfScene' ???????????
    }

    //constructor for 
    public EntranceToScene(GameObject entrance, string nameOfScene) //?????
    {
        this.entrance = entrance;
        this.NameOfScene = nameOfScene;
    }

}
