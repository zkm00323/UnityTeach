using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class WorkMono : MonoBehaviour
{
    //public Button[] hours; 
    public GameObject jobPanel;
    MoneyUI playerMoney;
    public Work workSO; //the SO
    public PlayerStats playerStats;
    
    // Start is called before the first frame update
    void Start()
    {
        playerMoney = GameObject.Find("player").GetComponent<MoneyUI>();
        playerStats = GameObject.Find("player").GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        //if work button is clicked, call the function
    }

    public void ShowWorkWindow()
    {
        //when player select job area, show the work UI panel 
        //CanvasObject.GetComponent<Canvas>().enabled = true;
        
    }
    public void OnWorkButtonClicked(int hoursWorked) //this variable receive info when function is called
    {
        playerMoney.AddMoney(hoursWorked * workSO.hourlyWage);
        playerStats.hunger += hoursWorked * workSO.hourlyHungerImpact;
        playerStats.hygiene += hoursWorked * workSO.hourlyHygieneImpact;
        playerStats.energy += hoursWorked * workSO.hourlyEnergyImpact;



        //make an UI that allows player to select how many hours they want to work
        //skills specific to the job increase; same thing as playermoney 
        //time passed
        //energy, hunger, and hygiene goes down
    }

    public void ShowPanel()
    {
        jobPanel.SetActive(true);
    }
    public void HidePanel()
    {
        jobPanel.SetActive(false);
    }

}
