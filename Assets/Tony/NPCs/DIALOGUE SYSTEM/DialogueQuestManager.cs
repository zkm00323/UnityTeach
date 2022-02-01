using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


public class DialogueQuestManager : MonoBehaviour, IPointerClickHandler //attach on NPC with quests *tick off 'has visited' after each play
{

    public NPCDialogue dialogue;
    [SerializeField]
    private GameObject dialogueUI; //make it a bark above npc's head
    public QuestGiver questGiver;


    [SerializeField]
    private List<NPCDialogue> DialogueSOList = new List<NPCDialogue>();



    private Queue<string> sentences; //first in first out



    [SerializeField] public List<GameObject> playerChoices = new List<GameObject>();

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    //public Text playerResponse;


    void Start()
    {
        dialogueUI = FindObjectOfType<DialogueUI>(includeInactive: true).gameObject; //doesn't find because it only finds active objects in scene
        //dialogueUI = GameObject.Find("Canvas").transform.GetChild(15).gameObject; //find the UI under Canvas; the 15th child object

        for (int i = 0; i < playerChoices.Count; i++) //populate the text fields on runtime instead of dragging
        {
            playerChoices[i] = dialogueUI.GetComponent<DialogueUI>().buttons[i];
        }

        foreach (GameObject buttons in playerChoices) //hide the buttons 
        {
            buttons.gameObject.SetActive(false);
        }

        nameText = FindObjectOfType<DialogueUI>(includeInactive: true).NPCname;
        dialogueText = FindObjectOfType<DialogueUI>(includeInactive: true).DialogueText;


    }

    public void OnPointerClick(PointerEventData eventData)
    {        
        FindObjectOfType<DialogueUI>(includeInactive: true).d = transform.GetComponent<DialogueQuestManager>(); //connect UI d manager to d manager on NPC

        Debug.Log("Clicked on chat NPC");

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

    }
    void EndDialogue()
    {
        
        DisplayChoices();
        dialogue.hasVisited = true;

    }
    public void DisplayChoices()
    {
        

        
        for (int i=0; i<dialogue.playerDialogue.Count; i++) //set number of buttons equal to number of player response in the dialogue SO
        {
            
           playerChoices[i].gameObject.SetActive(true); //show the buttons
           playerChoices[i].GetComponentInChildren<Text>().text = dialogue.playerDialogue[i]; //populate button text with the right dialogues


        }

        
    }

    public void Choice1() //link to inspector
    {
        //this button supposedly doesn't do anything, like "ok" or "got it" 
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
