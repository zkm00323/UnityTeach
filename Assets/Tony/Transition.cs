using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Transition : MonoBehaviour
{
	//To which level are we going to?
	public int TargetedSceneIndex;

	//TargetPlayerLocation will be saved in Global, and then set to the player
	//after the scene transition, so the player is in correct spot in the new scene.
	public Transform TargetPlayerLocation;

	//Text displayed on HUD when aiming at the Object.
	public string Description;

	/*public void AimAt()
	{
		HUDScript.AimedObjectString = Description;
	}*/

	public void Interact()
	{

		//Assign the transition target location.
		GameCtrl_.Instance.TransitionTarget.position = TargetPlayerLocation.position;
		//New:
		GameCtrl_.Instance.IsSceneBeingTransitioned = true;
		GameCtrl_.Instance.FireSaveEvent();
		SceneManager.LoadSceneAsync(TargetedSceneIndex);

	}
}
