using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "MySO/PlaceableItemInfo")]
public class PlaceableItemInfoSO : ItemInfoSO{
	public GameObject Object;
	public PlaceableItemType Type;
}

public enum PlaceableItemType{
	Chairs,Table, Bed,ElectronicAppliances, Lightings, Kitchen, Storageware, Bathroom, Decorations, Miscelleneous
}
