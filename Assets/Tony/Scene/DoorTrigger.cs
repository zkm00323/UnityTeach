using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{


    public GameObject houseDoor;
    private void OnTriggerEnter(Collider other)
    {
        print(other.name);
        if(other.gameObject.tag.Equals("Player"))HouseDoorCtrl.Exit();
    }
}
