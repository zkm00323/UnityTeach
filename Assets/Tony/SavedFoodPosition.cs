using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SavedFoodPosition 
{
    public float PositionX, PositionY, PositionZ;
}

[Serializable]
public class SavedDroppableList
{
    public int SceneID;
    public List<SavedFoodPosition> SavedFood;

    public SavedDroppableList (int newSceneID)
    {
        this.SceneID = newSceneID;
        this.SavedFood = new List<SavedFoodPosition>();
    }
}

