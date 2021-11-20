using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour //attach to quest giver can be a button, item, NPC etc
{

    [SerializeField] private string questName;
    private QuestController questController;
    private Quest quest; //name needs to be the same as the name of the quest script

    void Start()
    {
        questController = FindObjectOfType<QuestController>(); //set it in runtime so to makesure it will always find the quest controller
        
    }

    public void GiveQuest() //call this method when player is talking to npc?
    {
        quest =questController.AssignQuest(questName);
        GetComponent<UnityEngine.UI.Button>().image.color = Color.green;
    }
}
