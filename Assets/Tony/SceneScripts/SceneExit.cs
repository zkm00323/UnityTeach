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
      //pop up window asking player if he wants to go in--> if enter then invoke scene change

    }
    public void SceneChangeDelay()
    {
        SceneCtrl.Instance.ChangeScene(sceneToLoad); //switch to new scene
        GameCtrl.Instance.EnterDoor(previousScene, sceneToLoad); //make sure player is transported to right location in new scene
    }


}
