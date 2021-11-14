using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreviousScene : MonoBehaviour //put this to an empty game object in EVERY scene
{
    public static string PreviousLevel { get; private set; }
    Scene _currentScene;

    private void Start()
    {
        _currentScene = SceneManager.GetActiveScene(); 
        
    }
    private void OnDestroy()
    {
        PreviousLevel = _currentScene.name; //or just do gameObject.scene.name;
        Debug.Log(PreviousLevel);
    }

    /*public static string PreviousLevel { get; private set; }
     private void OnDestroy()
     {
         PreviousLevel = gameObject.scene.name;
     }
     
     private void Start()
     {
         Debug.Log(Level.PreviousLevel);  // use this in any level to get the last level.
     }
    */
}
