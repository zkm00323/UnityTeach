using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FurnitureObject : ItemObject
{
    [SerializeField]
    private string furnitureName;
    [SerializeField]
    private Sprite icon;
    [SerializeField]
    private float price;

    public void Awake()
    {   
        type = ItemType.Furnitures;

    }

    public void Use()
    {
        //play animation
    }    


}
