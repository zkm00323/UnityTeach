using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NPC files", menuName ="NPC files archive")] 
public class NPCDialogue : ScriptableObject
{
    public string NPCname;
    [TextArea(3, 15)]
    public List<string> npcDialogue = new List<string>();

    [Header("player response")]
    [TextArea(3, 15)]

    public List<string> playerDialogue = new List<string>();

    public bool hasVisited;


    //To keep track of dialogue progress
    //private Dictionary<NPCDialogue, bool> DialogueDatabase = new Dictionary<NPCDialogue, bool>();
    //if this dialogue is completed--> take it off database
    //OR
    //private static int [] progress = new int[30]; //contains number 0 to 30
    

}
