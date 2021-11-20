using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDatabase : MonoBehaviour //attach to a Questing gameobject
{
    //dictionary to keep track of what quest has what status
    //key- quest name     value- array of int
    public Dictionary<string, int[] > QuestData= new Dictionary<string, int[]>();
    //int[x, y]
    //x= if not completed 0, if completed 1 
    //y= current count 

    private void Awake()
    {
        EventController.OnQuestProgressChanged += UpdateQuestData; //register UpdateQuestData to the event 
    }


    public bool Completed(string questName) //return a bool value 
    {
        if (QuestData.ContainsKey(questName))
        {
            //return true if contains the key meaning quest is completed
            return System.Convert.ToBoolean(QuestData[questName][0]); //0 becos we want to see the first value in the int array aka the status value 
        }
        return false; //quest was not completed
    }


    public void AddQuest(Quest quest) //add a quest to the database
    {
        QuestData.Add(quest.questName, new int[] { 0, 0 });
    }

    public void UpdateQuestData(Quest quest)
    {
        QuestData[quest.questName] = new int[] {System.Convert.ToInt32(quest.completed), quest.goal.countCurrent };
        Debug.Log("Data updated for: " + quest.questName);
    }





}
