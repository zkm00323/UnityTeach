using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCData 
{
    private static bool isDatingPlayer = false;
    private static int relationshipPoints;
    private List<NPCQuest> npcQuestList = new List<NPCQuest>();
    private List<CraftingRecipe> recipeList = new List<CraftingRecipe>();
    private List<ItemData> favoriteItems = new List<ItemData>();
    private Dictionary<int, string>Dialogue = new Dictionary<int, string>();

    //constructor

    public virtual void NPCTalk()
    {

    }
}


 
public class NPCQuest
{

}
