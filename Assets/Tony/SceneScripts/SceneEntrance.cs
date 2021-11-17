using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEntrance : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPoint1;
    [SerializeField]
    private Transform spawnPoint2;
    private Transform spawnPoint3;
    private Transform spawnPoint4; //and so on

    

    private void Awake()
    {
        //MovePlayerHere();
        Debug.Log("player is moved!");
    }
    //public Transform ExitPos;
    
    //different scene has different spawn point

    /*public void MovePlayerHere()
    {
        //if previous scene name == xxx 
       if (PreviousScene.PreviousLevel == "MAINScene" )
        PlayerMovement.Player.GetComponent<CharacterController>()
               .Move(spawnPoint1.position);

        if (PreviousScene.PreviousLevel == "ConvenienceStore")
            PlayerMovement.Player.GetComponent<CharacterController>()
               .Move(spawnPoint2.position);
    }*/

    
    //method that checks for last scene
    

}
