using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameCtrl_ : MonoBehaviour {
    public static GameCtrl_ Instance;

    public ShopCtrl Shop;
    public WorkCtrl Work;
    public PlayerSkillsCtrl playerSkill; //not working in inspector???

    public Transform TransitionTarget;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        if (TransitionTarget == null)
            TransitionTarget = gameObject.transform;
    }

    //to save object states/positions in each scene
    public List<SavedDroppableList> SavedLists = new List<SavedDroppableList>();
    public delegate void SaveDelegate(object sender, EventArgs args);

    #region Notes on Events
    //only this class can fire the event(the class contains the event declaration)
    #endregion

    public static event SaveDelegate SaveEvent;

    public SavedDroppableList GetListForScene() //????
    {
        for (int i = 0; i < 10; i++);
        return new SavedDroppableList(1);
    }

    public void InitializeSceneList()
    {
        if (SavedLists == null)
        {
            print("Saved lists was null");
            //SavedLists = new List();
        }
        bool found = false;

    }
    public bool IsSceneBeingTransitioned = false;
    public bool IsSceneBeingLoaded = false;


    public void FireSaveEvent()
    {
        GetListForScene().SavedFood = new List<SavedFoodPosition>();
        //If we have any functions in the event:
        if (SaveEvent != null)
            SaveEvent(null, null);
    }

    public void SaveData()
    {
        if (!Directory.Exists("Saves"))
            Directory.CreateDirectory("Saves");

        FireSaveEvent();

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream saveFile = File.Create("Saves/save.binary");
        FileStream SaveObjects = File.Create("saves/saveObjects.binary");


        formatter.Serialize(SaveObjects, SavedLists);

        saveFile.Close();
        SaveObjects.Close();

        print("Saved!");
    }

    public void LoadData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream saveFile = File.Open("Saves/save.binary", FileMode.Open);
        FileStream saveObjects = File.Open("Saves/saveObjects.binary", FileMode.Open);

        SavedLists = (List<SavedDroppableList>)formatter.Deserialize(saveObjects);

        saveFile.Close();
        saveObjects.Close();

        print("Loaded");
    }



}
