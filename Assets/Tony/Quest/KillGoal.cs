using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillGoal : Goal //inherit from goal base class
{
    public int enemyID; //when enemy dies killgoal will check if it matches the ID here

    public KillGoal (int amountNeeded, int enemyID, Quest quest) //constructor
    {
        countCurrent = 0; //initialize it to 0
        countNeeded = amountNeeded;
        completed = false;
        this.quest = quest;
        this.enemyID = enemyID;
        EventController.OnEnemyDied += EnemyKilled; //assign EnemyKilled to event OnEnemyDied
    }

    void EnemyKilled(int enemyID) //this is a listener to the action OnEnemyDied
    {
        if (this.enemyID== enemyID)
        {
            Increment(1); //increment is from base goal class
        }
    }







    }
