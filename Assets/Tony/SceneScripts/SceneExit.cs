using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneExit : MonoBehaviour
{
    public string sceneToLoad;
    public string previousScene;

    private float delayTime = 1f;

    private void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.tag.Equals("Player"))
        {
            Invoke("SceneChangeDelay", delayTime);


        }


    }
    void SceneChangeDelay()
    {
        SceneCtrl.Instance.ChangeScene(sceneToLoad);
        GameCtrl.Instance.EnterDoor(previousScene, sceneToLoad);
    }


}
