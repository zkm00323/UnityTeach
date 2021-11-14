using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestUIItem : MonoBehaviour //attach to each quest prefab slot
{
    [SerializeField]
    private TMP_Text questName, questProgress;
    private Quest quest;


    private void Start()
    {
        EventController.OnQuestCompleted += QuestCompleted; //register QuestCompleted UI to the OnQuestCompleted event
        EventController.OnQuestProgressChanged += UpdateProgress;
    }
    public void Setup(Quest questToSetup) //allows you to change quest name in inspector
    {
        questName.text = questToSetup.questName;
        questProgress.text = questToSetup.goal.countCurrent + "/" + questToSetup.goal.countNeeded;
    }

    public void UpdateProgress(Quest quest)
    {
        if (this.quest == quest)
        {
            questProgress.text = quest.goal.countCurrent + "/" + quest.goal.countNeeded;

        }

    }


    public void QuestCompleted (Quest quest) //deletes the UI Item whenever the OnQuestCompleted event occurs.
    {
        if (this.quest == quest)
        {
            Destroy(this.gameObject, 1f); //do on a 1 sec delay so we can see it
        }
    }
}
