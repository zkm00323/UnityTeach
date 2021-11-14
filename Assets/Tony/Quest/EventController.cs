using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour //event controller for Quests
{
    //define actual event aka delegate that will trigger its listeners
    public static event System.Action<int> OnEnemyDied = delegate { }; //int is the enemyID;  assign to empty delgate to make sure its not null
    public static event System.Action<Quest> OnQuestProgressChanged = delegate { };
    public static event System.Action<Quest> OnQuestCompleted = delegate { };

    

    //we need to invoke the above events in the folloiwng EVENT HANDLERS;
    public static void EnemyDied(int enemyID)
    {
        OnEnemyDied(enemyID); //call the event above!!!!
    }

    public static void QuestProgressChanged(Quest quest) //we need to know which quest it is
    {
        OnQuestProgressChanged(quest); //call the event above!!!!
    }

    public static void QuestCompleted(Quest quest)
    {
        OnQuestCompleted(quest); //call the event above!!!!
    }
}
