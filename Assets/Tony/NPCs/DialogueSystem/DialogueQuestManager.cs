using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class DialogueQuestManager : MonoBehaviour, IPointerClickHandler //attach on NPC with quests
{

    public NPCDialogue dialogue;
    [SerializeField]
    private List<NPCDialogue> DialogueSOList = new List<NPCDialogue>();


    public QuestGiver questGiver;

    private Queue<string> sentences; //first in first out



    public GameObject dialogueUI; //make it a bark above npc's head
    [SerializeField] private List<GameObject> playerChoices = new List<GameObject>();

    public Text nameText;
    public Text dialogueText;
    //public Text playerResponse;


    void Start()
    {
        foreach(GameObject buttons in playerChoices)
        {
            buttons.gameObject.SetActive(false);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //find dialogueUI UI first in scene and set it active
        //dialogueUI = FindObjectWithName("xxxx")
        dialogueUI.SetActive(true);
        foreach (GameObject buttons in playerChoices)
        {
            buttons.gameObject.SetActive(false);
        }
        //StartDialogue(dialogue);
        

 

        foreach (NPCDialogue i in DialogueSOList)
        {
            if (i.hasVisited==false)
            {
                dialogue = i;
                StartDialogue(i);

                break;
            }
            

        }


    }

    public void StartDialogue(NPCDialogue dialogue)
    {
        sentences = new Queue<string>(dialogue.npcDialogue);

        Debug.Log("Starging conversation with NPC ");
        nameText.text = dialogue.NPCname;
        
        sentences.Clear();

        /*foreach(string sentence in dialogue.npcDialogue)
        {
            sentences.Enqueue(sentence);
        }*/

        for (int i=0; i<dialogue.npcDialogue.Count; i++)
        {
            sentences.Enqueue(dialogue.npcDialogue[i]);
            Debug.Log("displaying dologues in npcDialogue"); //DIDN"T RUN
        }



        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {   if( sentences.Count == 0)
        {
            EndDialogue();
            return;

        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;

        Debug.Log("Displaying next sentence");
    }
    void EndDialogue()
    {
        Debug.Log("End of convo");
        
        DisplayChoices();
        dialogue.hasVisited = true;

    }
    public void DisplayChoices()
    {
        foreach (GameObject buttons in playerChoices)
        {
            buttons.gameObject.SetActive(true);
        }

        for (int i = 0; i < playerChoices.Count; i++) //also player making choices
        {
            playerChoices[i].GetComponentInChildren<Text>().text = dialogue.playerDialogue[i];
            //buttonobj.GetComponentInChildren<Text>().text = "bla bla";

        }
    }

    public void Choice1()
    {

    }

    public void Choice2()
    {
        //call QuestGiver and assign quest

    }

    public void Choice3()
    {

    }

    public void CloseDialogueWindow()
    {
        dialogueUI.SetActive(false);
    }


    /*
            foreach(NPCDialogue dialogue in DialogueSOList)
        {
            if (!dialogue.hasVisited)
            {
                StartDialogue(dialogue);
            }
        }
    */
   

}
