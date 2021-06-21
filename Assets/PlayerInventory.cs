using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    #region Singleton
    public static PlayerInventory instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found");
            return;
        }
        instance = this;
    }

    #endregion
    public List<ItemObject> myInventory = new List<ItemObject>(); //creating a reeference
    GameObject player;


    // Start is called before the first frame update
    void Start()
    {
         //create a list and save inside inventory variable
        //inventory.Add(ScriptableObject.CreateInstance<FoodObject>());

    }

    public void AddItem(ItemObject item)
    {
        myInventory.Add(item);
    }

    public void RemoveItem(ItemObject item)
    {
        myInventory.Remove(item);
    }

    /*public List<InventoryItem> allItems = new List<InventoryItem>();

    private void Start()
    {
        for (int i = 0; i < allItems.Count; i++)
        {
            if (allItems[i].itemType == InventoryItem.ItemType.Wearable)
            {
                WearableItem wItem = allItems[i] as WearableItem;
            }
            // etc...
        }
    } */
}
