using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionGoal : Goal
{
    public int itemID; //when items collected CollectionGoal will check if it matches the ID here

    public CollectionGoal(int amountNeeded, int itemID, Quest quest) //constructor
    {
        countCurrent = 0; //initialize it to 0
        countNeeded = amountNeeded;
        completed = false;
        this.quest = quest;
        this.itemID = itemID;
        EventController.OnItemFound += ItemFound; //assign EnemyKilled to event OnEnemyDied
    }

    void ItemFound(int itemID) //this is a listener to the action OnEnemyDied
    {
        if (this.itemID == itemID)
        {
            Increment(1); //increment is from base goal class 
            Debug.Log("Found 1 item");
            if (this.completed)
            {
                EventController.OnItemFound -= ItemFound;
            }
        }
    }

}
