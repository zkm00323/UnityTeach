using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    public NPCDialogue npc;
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

    private void OnMouseOver()
    {
        StartCoroutine(DisplayDialogue());
        

    }
    IEnumerator DisplayDialogue()
    {
        if (Input.GetKeyDown(KeyCode.T) && isTalking == false)
        {
            StartConversation();
        }
        else if (Input.GetKeyDown(KeyCode.T) && isTalking == true)
        {
            EndDialogue();
        }

        for (int i = 0; i < ResponseButtons.Count; i++)
        {
            ResponseButtons[i].GetComponentInChildren<Text>().text = npc.playerDialogue[i];
            //buttonobj.GetComponentInChildren<Text>().text = "bla bla";

        }
        
        yield return new WaitForSeconds(1);
        //show npc response after player makes the choice

   
    }

    #region PlayerResponseButton //is there a better way to write this?
    public void Button1_Response()
    {
        optionSelected = true;

        //1 second delay then do the below
        npcDialogueBox.text = npc.npcDialogue[1];
        
    } //someButton.GetComponent<Button>().onClick.AddListener(() => SomeFunction(SomeParameter));

    public void Button2_Response()
    {
        optionSelected = true;

        npcDialogueBox.text = npc.npcDialogue[2];


    }
    public void Button3_Response()
    {
        optionSelected = true;


        npcDialogueBox.text = npc.npcDialogue[3];


    }
    #endregion 

    void StartConversation()
    {
        isTalking = true;
        currentResponseTracker = 0;
        npcName.text = npc.name;
        dialogueUI.SetActive(true);
        npcDialogueBox.text = npc.npcDialogue[0];

    }
    void EndDialogue()
    {
        isTalking = false;
        dialogueUI.SetActive(false);
    }

    
}
