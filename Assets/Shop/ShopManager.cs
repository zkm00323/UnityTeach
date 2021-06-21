using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    //public int playerMoney.money;
    public TMP_Text coinUI;
    //public ShopItemSO[] shopItemsSO;
    public FoodObject[] foodObjectSO; //make the food, hygiene, and furniture SO items sold in shop like shopItemsSO?
    public ShopTemplate[] shopPanels;
    public GameObject[] shopPanelsGO;
    public Button[] myPurchaseBtns;

    //reference to player money script
    public PlayerMoney playerMoney;


    private void Start()
    {
        for (int i = 0; i < foodObjectSO.Length; i++) //change shopItemsSO to foodObjectSO? 
            shopPanelsGO[i].SetActive(true);

        playerMoney = GameObject.Find("player").GetComponent<PlayerMoney>();
        //playerMoney.money
        coinUI.text = "Coins: " + playerMoney.money.ToString();
        LoadPanels();
    }

    public void AddCoins() //add playerMoney.money
    {
        playerMoney.money++;
            coinUI.text = "Coins: " + playerMoney.money.ToString();
        CheckPurchaseable();
    }

    public void CheckPurchaseable()
    {
        for (int i=0; i < foodObjectSO.Length; i++)
        {
            if (playerMoney.money >= foodObjectSO[i].price) //change to .price? 
                myPurchaseBtns[i].interactable = true;
            else
                myPurchaseBtns[i].interactable = false;
        }
    }
    public void LoadPanels()
    {
        for (int i =0; i<foodObjectSO.Length; i++)
        {
            shopPanels[i].titleTMP.text = foodObjectSO[i].foodName; //to foodObjectSO[i].foodName
            shopPanels[i].descriptionTMP.text = foodObjectSO[i].description;
            shopPanels[i].costTMP.text = "Price: " + foodObjectSO[i].price.ToString();
        }
    }

    public void PurchaseItem(int btnNo)
    {
        if (playerMoney.money >= foodObjectSO[btnNo].price)
        {
            playerMoney.money = playerMoney.money - foodObjectSO[btnNo].price;
            coinUI.text = "Coins: " + playerMoney.money.ToString();
            CheckPurchaseable();
        }
    }


}
