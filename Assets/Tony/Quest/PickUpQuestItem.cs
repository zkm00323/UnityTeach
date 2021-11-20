using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpQuestItem : ItemMono
{
    [SerializeField]
    private int QuestItemID; //different from regular item id
    [SerializeField]
    //private string thisQuestName;

    //private List<Quest> currentQuest= new List<Quest>();
    

    void Start()
    {
        QuestItemID = 100;
    }

    public override void OnClick()
    {
        //if quest is in active assigned quest list
        //if thisQuestName matches questName in the assigned quest name;
        //currentQuest = GetComponent<QuestController>().assignedQuests;

        //if (currentQuest.Find(quest => quest.questName == thisQuestName))
        PickUP();
        Destroy(gameObject);





    }


    public void PickUP() //whenver we pick a quest item we call this method
    {
        EventController.ItemFound(QuestItemID);

        Debug.Log("found item!"); //found
    }



    public override void OnPointerEnter()
    {
        /*GetComponent<MeshRenderer>().material = _m2;*/
        GetComponent<MeshRenderer>().material = _highlightMaterial;
        //_m.SetColor("_BaseColor", Color.green);
    }

    public override void OnPointerExit()
    {
        /*GetComponent<MeshRenderer>().material = _m1;*/
        //_m.SetColor("_BaseColor", Color.white);
        GetComponent<MeshRenderer>().material = _originalMaterial;
    }
}
