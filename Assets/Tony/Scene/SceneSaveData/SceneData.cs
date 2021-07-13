using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MySO/SceneData", order =1)]
public class SceneData : ScriptableObject{
	public List<ItemSaveData> ItemDataList;
}

[Serializable]
public class ItemSaveData{
	public Vector3 Pos;
	public Vector3 Rot;
	public ItemInfoSO Item;
}
