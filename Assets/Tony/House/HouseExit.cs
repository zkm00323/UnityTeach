using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseExit : SceneExit //attach this to every house door so furnitures can be saved
{
    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        HouseDoorCtrl.Exit();
    }
}
