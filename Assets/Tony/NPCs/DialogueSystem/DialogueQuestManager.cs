using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class DialogueQuestManager : MonoBehaviour, IPointerClickHandler
{
    private Queue<string> sentences; //first in first out
    public NPCDialogue dialogue;

    public GameObject dialogueUI; //make it a bark above npc's head
    [SerializeField] private List<GameObject> playerChoices = new List<GameObject>();

    public Text nameText;
    public Text dialogueText;
    //public Text playerResponse;


    void Start()
    {
        sentences= new Queue<string>(dialogue.npcDialogue);
        foreach(GameObject buttons in playerChoices)
        {
            buttons.gameObject.SetActive(false);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        dialogueUI.SetActive(true);
        foreach (GameObject buttons in playerChoices)
        {
            buttons.gameObject.SetActive(false);
        }
        StartDialogue(dialogue);



    }

    public void StartDialogue(NPCDialogue dialogue)
    {
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
        Debug.Log("End of convo");
        
        DisplayChoices();

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

    }

    public void Choice3()
    {

    }

    public void CloseDialogueWindow()
    {
        dialogueUI.SetActive(false);
    }

   

}
