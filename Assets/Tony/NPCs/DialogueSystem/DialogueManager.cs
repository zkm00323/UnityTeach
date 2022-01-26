using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class DialogueManager : MonoBehaviour, IPointerClickHandler //dialogue manager with choices triggering different responses from NPC
{
    public NPCDialogue dialogue;
    //create different dialogue object based on relationship level
    bool isTalking = false;
    float distance;
    float currentResponseTracker = 0;
    public GameObject player;
    public GameObject dialogueUI; //make it a bark above npc's head
    
    //public Button[] playerResponseButton;
    public List<GameObject> ResponseButtons = new List<GameObject>();

    public Text npcName;
    public Text npcDialogueBox;
    public Text playerResponse;

    bool optionSelected = false;


    // Start is called before the first frame update
    void Start()
    {
       dialogueUI.SetActive(false);
            /* // Offset position above object bbox (in world space)
      float offsetPosY = target.transform.position.y + 1.5f;
 
      // Final position of marker above GO in world space
      Vector3 offsetPos = new Vector3(target.transform.position.x, offsetPosY, target.transform.position.z);
 
      // Calculate *screen* position (note, not a canvas/recttransform position)
      Vector2 canvasPos;
      Vector2 screenPoint = Camera.main.WorldToScreenPoint(offsetPos);
 
      // Convert screen position to Canvas / RectTransform space <- leave camera null if Screen Space Overlay
      RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPoint, null, out canvasPos);
 
      // Set
      markerRtra.localPosition = canvasPos;*/


    }

    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(DisplayDialogue());
        

    }
    IEnumerator DisplayDialogue()
    {
        if ( isTalking == false)
        {
            StartConversation();
        }
        else if (isTalking == true)
        {
            EndDialogue();
        }

        for (int i = 0; i < ResponseButtons.Count; i++) //also player making choices
        {
            ResponseButtons[i].GetComponentInChildren<Text>().text = dialogue.playerDialogue[i];
            //buttonobj.GetComponentInChildren<Text>().text = "bla bla";

        }
        
        yield return new WaitForSeconds(1);
        //show npc response after player makes the choice

   
    }

    #region PlayerResponseButton 
    public void Button1_Response()
    {
        optionSelected = true; //call the quest giver?
        //questGiver.GiveQuest();

        //1 second delay then do the below
        npcDialogueBox.text = dialogue.npcDialogue[1];
        
    } //someButton.GetComponent<Button>().onClick.AddListener(() => SomeFunction(SomeParameter));

    public void Button2_Response()
    {
        optionSelected = true;

        npcDialogueBox.text = dialogue.npcDialogue[2];


    }
    public void Button3_Response()
    {
        optionSelected = true;


        npcDialogueBox.text = dialogue.npcDialogue[3];


    }
    #endregion 

    void StartConversation()
    {
        isTalking = true;
        currentResponseTracker = 0;
        npcName.text = dialogue.name;
        dialogueUI.SetActive(true);
        npcDialogueBox.text = dialogue.npcDialogue[0];  //dialogue SO is different based on friendship level

    }
    public void EndDialogue()
    {
        isTalking = false;
        dialogueUI.SetActive(false);
    }

    /*public void OnPointerEnter(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }*/
}
