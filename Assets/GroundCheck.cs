using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour //attach to foot?
{//Ground Check
    public bool onGround;

    /*private void OnTriggerStay(Collider other)
    {
        if (other == null)
            onGround = false;
        else
            onGround = true;
        
        //Debug.Log("Colliding Object: " + other.name);
    }*/

    private void OnTriggerExit(Collider other)
    {
        onGround = false ;
    }
}
