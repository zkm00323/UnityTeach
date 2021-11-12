using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour //For each quest accepted, add this to a game component in scene
{
    public string questName;
    public string description;
    public Goal goal;
    public bool completed;
    public List<string> itemRewards; //change this later to actual reward

    public virtual void Complete() 
    {
        Debug.Log("Quest completed!");
        EventController.QuestCompleted(this); //pass the quest to event handler QuestCompleted
        GrantReward();

    }

    public void GrantReward()
    {
        Debug.Log("Turning in quest...granting reward.");
        foreach(string item in itemRewards)
        {
            Debug.Log("Rewarded with: " + item);
        }
        Destroy(this); //destroy this QUEST Instance when completed 
    }

}
