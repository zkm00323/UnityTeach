using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float health;
    public float hunger;
    public float hygiene;
    public float energy;

    public float deathRate;
    public float hungerRate;
    public float hygieneRate;
    public float energyRate;

    public Slider HealthBar;
    public Slider HungerBar;
    public Slider HygieneBar;
    public Slider EnergyBar;

    public static PlayerStats Instance;

    private void Start()
    {
        //GameObject.DontDestroyOnLoad(this.gameObject);
        health = 100;
        hunger = 100;
        hygiene = 100;
        energy = 100;
    }
    // Update is called once per frame
    void Update()
    {

        //GameObject.DontDestroyOnLoad(this.gameObject);
        /*stats bar*/
        HealthBar.value = health;
        HungerBar.value = hunger;
        HygieneBar.value = hygiene;
        EnergyBar.value = energy;
        hunger = hunger - (hungerRate * Time.deltaTime);
        hygiene = hygiene - (hygieneRate * Time.deltaTime);
        //energy = energy - (energyRate * Time.deltaTime); //energy decrease by work??

        if (health <= 0)
        {
            health = 0;
            Debug.Log("Dead");
        }
        if (hunger <= 0 || hygiene <= 0)
        {
            health = health - (deathRate * Time.deltaTime);
        }
        if (hunger <= 20)
        {
            hunger = 0;
        }
        if (hygiene <= 10)
        {
            hygiene = 0;
        }
        if (energy <=30)
        {
            Debug.Log("Can't work");
        }

        //set max value to 100
        if (health >= 100)
        {
            health = 100;
        }
        if (hunger >= 100)
        {
            hunger = 100;
        }
        if (hygiene >= 100)
        {
            hygiene = 100;
        }
        if (energy >= 100)
        {
            energy = 100;
        }

    }

}
