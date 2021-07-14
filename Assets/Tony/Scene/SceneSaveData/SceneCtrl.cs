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
			if(_Instance == null) _Instance = new SceneCtrl(); //生成新的scene ctrl class
			return _Instance;
		}
	}

	public void ChangeScene(string sceneName){ //切換場警
		GameCtrl.Instance.StartCoroutine(WhenSceneChanges(sceneName));
	}

	public void Save(SceneData sceneData){
		if(sceneData != null){
			sceneData.ItemDataList = new List<ItemSaveData>(); //如果已經有個list了 要再重新創一個空的不然會加上次的進去 
			
			List<ItemSaveData> itemSaveDataList = new List<ItemSaveData>();
			foreach(var item in PickUpItem.AllItemInScene){ //場景物件list
				itemSaveDataList.Add(item.GetSaveData()); //GetSaveData= 物件的位置 資訊
			}
			PickUpItem.AllItemInScene = new List<PickUpItem>();
		
			sceneData.ItemDataList = itemSaveDataList;
		}
	}
	IEnumerator WhenSceneChanges(string sceneName){
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
