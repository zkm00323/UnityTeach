using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class HygieneObject : ItemObject
{
    private PlayerStats hygiene;

    [SerializeField]
    private string hygieneProductName;
    [SerializeField]
    private Sprite icon;
    [SerializeField]
    private float price;
    [SerializeField]
    private float restoreHygiene;

    public void Awake()
    {
        type = ItemType.HygieneProducts;

    }

    public void Clean()
    {
        GameObject.Find("player").GetComponent<PlayerStats>().hygiene += restoreHygiene;

    }
}
