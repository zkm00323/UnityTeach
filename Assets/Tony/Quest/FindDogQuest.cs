using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindDogQuest : Quest //derive from mono object quest
{
    void Awake() //we need this to immediately gets initialized before start 
    {
        questName = "Find Missing Dog";
        description = "Get that dog back!";
        itemRewards = new List<string> { "money", "Rusty Chain" };
        goal = new CollectionGoal(1, 100, this); //constructor from KillGoal-- goal is 5 vampires of ID0; this so KillGoal knows which quest to complete
        //set the dog ID to 100 for now

        
    }


        public override void Complete()
    {
        base.Complete(); //but can do anything other than what's in the base class complete()

        //If you override the event in the derived classes, you need to make sure to still call the QuestCompleted handler if you don’t call the base Complete method
    }


 }












