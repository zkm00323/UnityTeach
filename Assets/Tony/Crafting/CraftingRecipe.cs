using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Crafting Recipe", menuName ="New Crafting Recipe")]
public class CraftingRecipe : ScriptableObject
{
    public ItemInfoSO itemToCraft;
    public ResourceCost[] cost; //cost is an array of ItemInfoSO and quantity
}

[System.Serializable] //serialize this class so we can set it in inspector
public class ResourceCost //contain resource and quantities
{
    public ItemInfoSO item;
    public int quantity;
}