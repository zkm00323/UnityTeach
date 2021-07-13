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

	public void Save(SceneData sceneData){
		if(sceneData != null){
			sceneData.ItemDataList = new List<ItemSaveData>();
			
			List<ItemSaveData> itemSaveDataList = new List<ItemSaveData>();
			foreach(var item in PickUpItem.AllItemInScene){
				itemSaveDataList.Add(item.GetSaveData());
			}
			PickUpItem.AllItemInScene = new List<PickUpItem>();
		
			sceneData.ItemDataList = itemSaveDataList;
		}
	}
	IEnumerator DoChangeScene(string sceneName){
		//存檔
		Save(Resources.Load<SceneData>($"SceneData/{SceneManager.GetActiveScene().name}"));
		//換場景
		yield return SceneManager.LoadSceneAsync(sceneName);
		
		//讀檔
		var SceneData = Resources.Load<SceneData>($"SceneData/{sceneName}");
		//生成
		if(SceneData != null){
			foreach(var itemSaveData in SceneData.ItemDataList){
				PickUpItem.Gen(itemSaveData);
			}
		}

	}
}
