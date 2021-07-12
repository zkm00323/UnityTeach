using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCtrl{
	private static SceneCtrl _Instance;

	public static SceneCtrl Instance{
		get{
			if(_Instance == null) _Instance = new SceneCtrl();
			return _Instance;
		}
	}

	public void ChangeScene(string sceneName){
		GameCtrl.Instance.StartCoroutine(DoChangeScene(sceneName));
	}

	IEnumerator DoChangeScene(string sceneName){
		//todo 存檔
		var SceneData = Resources.Load<SceneData>($"SceneData/{SceneManager.GetActiveScene().name}");
		SceneData.ItemDataList.Clear();
		
		List<ItemSaveData> itemSaveDataList = new List<ItemSaveData>();
		foreach(var item in PickUpItem.AllItemInScene){
			itemSaveDataList.Add(item.GetSaveData());
		}
		PickUpItem.AllItemInScene.Clear();
		
		Debug.Log($"SceneData/{SceneManager.GetActiveScene().name}");
		SceneData.ItemDataList = itemSaveDataList;
		
		
		yield return SceneManager.LoadSceneAsync(sceneName);
		
		//todo 讀檔
		Debug.Log($"!!!+{sceneName}");
		SceneData = Resources.Load<SceneData>($"SceneData/{sceneName}");
		foreach(var itemSaveData in SceneData.ItemDataList){
			PickUpItem.Gen(itemSaveData);
		}
	}
}
