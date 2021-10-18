using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingWindow : MonoBehaviour 
    //manages overall UI elements of crafting panel& attached to canvas
{
    public CraftingRecipeUI[] recipeUIs;
    public static CraftingWindow instance; //a singleton instance of the window so we can access it anywhere in the project

    private void Awake()
    {
        instance = this;
    }

    //ways to open the window

    public void Craft (CraftingRecipe recipe) //take itemInfoSO 
    {
        //remove the used items from player's inventory
        for (int i=0; i<recipe.cost.Length; i++)
        {
            for (int x = 0; x < recipe.cost[i].quantity; x++); //call this line however many times there is this quantity in the inventory eg. 5 wood then call this 5 times
            PlayerData.Instance.RemoveItem(recipe.cost[i].item); //removeItem includes a call to update bag
        }

        //Add item crafted to player's inventory
        PlayerData.Instance.AddItem(recipe.itemToCraft.GetGetData()); //AddItem takes in ItemData not ItemInfo so use GetGetData to convert

    }
}
