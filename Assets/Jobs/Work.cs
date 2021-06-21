using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu]
public class Work : ScriptableObject
{
    PlayerMoney playerMoney;
    //public float hoursWorked;
    public int hourlyWage;
    public float hourlyHungerImpact;
    public float hourlyHygieneImpact;
    public float hourlyEnergyImpact;
    
    // Start is called before the first frame update
    void Awake()
    {

    }

    

    //SO: shared among jobs but different between jobs
}
