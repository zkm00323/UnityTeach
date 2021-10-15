using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddReduceMoney : MonoBehaviour
{

    public GameObject player; //player money script is attached to player
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (//player goes to work, found money in trash, offered money by npc, etc)
        {
            player.GetComponent<PlayerMoney>().AddMoney(5); //reference this line in other script in the future
        } */
        if (Input.GetButtonDown("Fire2"))
        {
            player.GetComponent<MoneyUI>().SubtractMoney(5);

        }
    }

    
}
