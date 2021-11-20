using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal //doesn't need to be attached to any objct
{
    public int countNeeded;
    public int countCurrent;
    public bool completed;
    public Quest quest;

    //increment current count value
    public void Increment(int amount)
    {
        countCurrent = Mathf.Min(countCurrent + amount, countNeeded); //Mathf.Min finds the lower one in the two values
        Debug.Log("Increment!!!");
        if (countCurrent >= countNeeded)
        {
            this.completed = true;
            Debug.Log("Goal completed!");
            quest.Complete(); //complete the quest
        }
        EventController.QuestProgressChanged(quest); //pass the quest to the handler QuestProgressChanged
    }



}
