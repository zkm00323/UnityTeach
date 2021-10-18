using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class MoneyUI : MonoBehaviour
{
    public static MoneyUI playerMoney;
    
 
    public TextMeshProUGUI moneyText; //reference to the UI money display
    void Start(){
        playerMoney = this;
        moneyText.text = "coins: "+ PlayerData.Instance.money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMoney(int moneyToAdd)
    {
        PlayerData.Instance.money += moneyToAdd;
        moneyText.text = "coins: " + PlayerData.Instance.money.ToString();

    }
    public bool SubtractMoney(int moneyToSubtract)
    {
        if (PlayerData.Instance.money - moneyToSubtract < 0) {
            Debug.Log("not enough money!!");
            return false;
        }
        PlayerData.Instance.money -= moneyToSubtract;
        moneyText.text = "coins: " + PlayerData.Instance.money.ToString();

        return true;
    }
}
