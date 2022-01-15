using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneExit : MonoBehaviour
{
    public string sceneToLoad;
    public string previousScene;

    private float delayTime = 1f;

    public virtual void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.tag.Equals("Player"))
        {
            Invoke("SceneChangeDelay", delayTime);


        }


    }
    public void SceneChangeDelay()
    {
        SceneCtrl.Instance.ChangeScene(sceneToLoad);
        GameCtrl.Instance.EnterDoor(previousScene, sceneToLoad);
    }


}
