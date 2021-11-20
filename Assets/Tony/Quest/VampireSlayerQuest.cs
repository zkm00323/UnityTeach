using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampireSlayerQuest : Quest //derive from mono object quest
{
    void Awake() //we need this to immediately gets initialized before start 
    {
        questName = "Vampire Slayer";
        description = "slay some vampires";
        itemRewards = new List<string> { "Burnt Salmon", "Rusty Chain" };
        goal = new KillGoal(10, 0, this); //constructor from KillGoal-- goal is 5 vampires of ID0; this so KillGoal knows which quest to complete

        
    }


        public override void Complete()
    {
        base.Complete(); //but can do anything other than what's in the base class complete()

        //If you override the event in the derived classes, you need to make sure to still call the QuestCompleted handler if you don’t call the base Complete method
    }


 }












