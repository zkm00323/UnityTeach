using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMoney : MonoBehaviour
{
    public float money;
    public Text moneyText; //reference to the UI money display
    void Start()
    {
        money = 5;
        moneyText.text = "coins: "+ money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMoney(int moneyToAdd)
    {
        money += moneyToAdd;
        moneyText.text = "coins: " + money.ToString();

    }
    public void SubtractMoney(int moneyToSubtract)
    {
        if (money - moneyToSubtract < 0)
        {
            Debug.Log("not enough money!!");
        }
        else
        {
            money = +moneyToSubtract;
            moneyText.text = "coins: " + money.ToString();

        }
    }
}
