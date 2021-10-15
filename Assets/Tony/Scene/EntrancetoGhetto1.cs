using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntrancetoGhetto1 : MonoBehaviour
{
    public GameObject entrance;
    private void OnTriggerEnter(Collider other)
    {
        //print(other.name);
        if (other.gameObject.tag.Equals("Player")) 
        SceneCtrl.Instance.ChangeScene(Define.Scene.GhettoStreet);


    }
}
