using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestController : MonoBehaviour //attach to a Questing gameobject
{
    public List<Quest> assignedQuests = new List<Quest>(); //currently assigned quests
    [SerializeField]
    private QuestUIItem questUIItem; //each slot prefab
    [SerializeField]
    private Transform questUIParent; //content on the quest canvas

    private QuestDatabase questDatabase;


    private void Start()
    {
        questDatabase = GetComponent<QuestDatabase>();
    }

    public Quest AssignQuest(string questName)
    {
        if (assignedQuests.Find( quest=> quest.questName== questName))  // => lamda expression. On the left is what we find and on the right is what we are going to do with it

        {
            Debug.LogWarning("Quest already assigned!"); //so if we find a quest that already exists in the list assigned quest we return null
            return null;
        }

        //if the quest has not been assigned, convert type

        Quest questToAdd = (Quest)gameObject.AddComponent(System.Type.GetType(questName)); //take the questname and convert it to type Quest
        assignedQuests.Add(questToAdd); //add the new quest to the list 
        questDatabase.AddQuest(questToAdd); //add this to the quest database


        QuestUIItem questUI = Instantiate(questUIItem, questUIParent); //instantiate in UI
        questUI.Setup(questToAdd); //call the setup method in UI
       
        return questToAdd; //return the item so quest gameobject has a reference to the new assigned quest
    }



}
