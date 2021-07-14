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

   


}
