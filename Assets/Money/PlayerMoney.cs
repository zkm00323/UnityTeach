using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMoney : MonoBehaviour
{
    public static PlayerMoney playerMoney;
    
    public float money;
    public Text moneyText; //reference to the UI money display
    void Start(){
        playerMoney = this;
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
    public bool SubtractMoney(int moneyToSubtract)
    {
        if (money - moneyToSubtract < 0) {
            Debug.Log("not enough money!!");
            return false;
        }
        print("!!!-"+moneyToSubtract);
        money -= moneyToSubtract;
        moneyText.text = "coins: " + money.ToString();

        return true;
    }
}
