using System;
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

    public void DoUpdate() {
        OpenCraftWindow();
    }

    //ways to open the window
    public KeyCode key;
    public Zoomer CraftWindow;
    
    public void OpenCraftWindow() 
         {
            if (CraftWindow.gameObject.activeSelf)
                CraftWindow.ZoomOut();
            else 
                CraftWindow.ZoomIn();
        }
       
    

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

        
        //tells that recipe UI to show green meaning craftable now //this needs to happen before we close the craft window
        for (int i=0; i<recipeUIs.Length; i++)
        {
            recipeUIs[i].UpdateCanCraft();
            Debug.Log("updating recipe UI");
        }
    }
}
