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

    
   


}
