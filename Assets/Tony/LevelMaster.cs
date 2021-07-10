using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMaster : MonoBehaviour
{
    public GameObject FoodPrefab;
    void Start()
    {
        GameCtrl.Instance.InitializeSceneList();
        GameCtrl.Instance.InitializeSceneList();

        if (GameCtrl.Instance.IsSceneBeingLoaded || GameCtrl.Instance.IsSceneBeingTransitioned)
        {
            SavedDroppableList localList = GameCtrl.Instance.GetListForScene();

            if (localList != null)
            {
                print("Saved potions count: " + localList.SavedFood.Count);

                for (int i = 0; i < localList.SavedFood.Count; i++)
                {
                    GameObject spawnedFood = (GameObject)Instantiate(FoodPrefab);
                    spawnedFood.transform.position = new Vector3(localList.SavedFood[i].PositionX,
                                                                    localList.SavedFood[i].PositionY,
                                                                    localList.SavedFood[i].PositionZ);
                }
            }
            else
                print("Local List was null!");
        }

    }
}
