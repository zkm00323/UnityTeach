using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchTrash : ItemMono { //attach this on trashcan objects in scene

	//get last object in scene; if last object exists, get it
	private GameObject foodInTrash;
	public Transform moveFoodHere;

    private void Start()
    {
		//foodInTrash = GetComponent<GenItemInScene>().GenObj;
    }

    public override void OnClick()
	{
		SearchforFood();

	}
	private void SearchforFood()
    {
		Debug.Log("you searched for trash");
		foodInTrash = GenItemInScene.LastObj; 

		if (foodInTrash != null)
		{
			//make the object outside or above trashcan 
			foodInTrash.transform.position = moveFoodHere.position;
			Debug.Log("moved trash");
		}

		//input audio of rummaging through trash
		//show a message saying 'Searched Trashcan- you found a piece of XXXX (item name)
		//If not--> you found nothing here

	}












	#region ColorChange

	private void AwakeColorChange() //see ItemMono for material variables
	{
		_originalMaterial = GetComponent<MeshRenderer>().material;
	}

	#endregion

	public override void OnPointerEnter()
	{
		
		GetComponent<MeshRenderer>().material = _highlightMaterial;
		
	}

	public override void OnPointerExit()
	{
		
		GetComponent<MeshRenderer>().material = _originalMaterial;
	}
}
