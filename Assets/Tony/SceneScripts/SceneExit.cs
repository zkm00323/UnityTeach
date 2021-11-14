using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneExit : MonoBehaviour
{
    public string sceneToLoad;
    [SerializeField]
    private Transform spawnPoint;


    private void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.tag.Equals("Player"))
            SceneCtrl.Instance.ChangeScene(sceneToLoad);
        /*PlayerMovement.Player.GetComponent<CharacterController>()
                 .Move(spawnPoint.position);*/

    }


}
