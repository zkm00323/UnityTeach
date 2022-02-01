using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUI : MonoBehaviour //REMEMBER TO drag response UI in the inspector!!
{
    public GameObject[] buttons = new GameObject[3];

    public TextMeshProUGUI NPCname;
    public TextMeshProUGUI DialogueText;

    public DialogueQuestManager d;

    public void NextSentenceButton()
    {
        d.DisplayNextSentence();
        Debug.Log("Displaying next");
    }

    public void CloseButton()
    {
        d.CloseDialogueWindow();
    }
    //public DialogueQuestManager next ;

    //get the element from chatNPC

    /*public void CloseDialogueWindow()
    {
        gameObject.SetActive(false);
    }

    public void NextSentence()
    {
        GetComponent<DialogueQuestManager>().DisplayNextSentence();
    }*/
}
