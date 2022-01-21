using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "MySO/PlaceableItemInfo")]
public class PlaceableItemInfoSO : ItemInfoSO{
	public GameObject Object; //for house UI
	public PlaceableItemType Type;
	/*public int hygienePoints;
	public int energyPoints; //add this to playerdata later
	public int moodPoints; //add to playerdata later*/

   
}

public enum PlaceableItemType{
	Chairs,Table, Bedroom,ElectronicAppliances, Lightings, Kitchen, Cabinets, Bathroom, Decorations, Miscelleneous
}
