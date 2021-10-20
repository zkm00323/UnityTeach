using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CraftingRecipeUI : MonoBehaviour 
    //manages individual recipes in the UI panel & attached to EACH crafting recipe in UI
{
    public CraftingRecipe recipe;
    public Image backgroundImage;
    public Image icon;
    public TextMeshProUGUI itemName;
    public Image[] resourceCosts;

    public Color canCraftColor;
    public Color cannotCraftColor;
    private bool canCraft;


    private void OnEnable()
    {
        UpdateCanCraft(); 
    }
    public void UpdateCanCraft() //check to see if we have enough resources to craft
    {
        canCraft = true;

        for(int i=0; i<recipe.cost.Length; i++)
        {
            for (int x=0; x<PlayerData.Instance.ItemList.Count; x++)
                if ((PlayerData.Instance.ItemList[x].Info != recipe.cost[i].item) && (PlayerData.Instance.ItemList[x].Count != recipe.cost[i].quantity))  //playerdata DOES NOT have that item and enough amount
                {
                    canCraft = false;
                    break;
                }
        }

        backgroundImage.color = canCraft ? canCraftColor : cannotCraftColor; //if true set to canCraftcolor and if not true set to else

            
    }

    private void Start() //at the start have the UI panels display each recipe with its correct icons and names
    {
        icon.sprite = recipe.itemToCraft.ItemImage.sprite;
        itemName.text = recipe.itemToCraft.Name;

        for (int i=0; i<resourceCosts.Length; i++) //we have 4 resource cost so disable the ones we don't need
        {
            if (i < recipe.cost.Length)
            {
                resourceCosts[i].gameObject.SetActive(true);
                resourceCosts[i].sprite = recipe.cost[i].item.ItemImage.sprite; //set icon
                resourceCosts[i].transform.GetComponentInChildren<TextMeshProUGUI>().text = recipe.cost[i].quantity.ToString(); //set amount
            }
            else resourceCosts[i].gameObject.SetActive(false);
        }
        
    }

    public void OnClickButton()
    {
        if (canCraft)
        {
            CraftingWindow.instance.Craft(recipe);
        }
    }

}
