using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FoodObject : ItemObject
{
    private PlayerStats hunger;
    
    [SerializeField]
    public string foodName;
    [SerializeField]
    private Sprite icon;
    [SerializeField]
    public float price; //reference to ShopItem base cost variable
    //public ShopItemSO baseCost;
    [SerializeField]
    private float restoreHunger;
   
    public void Awake()
    {
        type = ItemType.Food;
        
    }

    public void Eat()
    {
        GameObject.Find("player").GetComponent<PlayerStats>().hunger += restoreHunger;
        
    }


    public string FoodName
    {
        get
        {
            return foodName;
        }
    }
    public Sprite Icon
    {
        get
        {
            return icon;
        }
    }

    /*public float Price
    {
        get
        {
            return price;
        }
    }*/

    public float RestoreHunger
    {
        get
        {
           
           return restoreHunger;
        }
    }

   
        

}
