using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour //attach to foot?
{//Ground Check
    private bool onGround;
    private void OnCollisionEnter(Collision collsion)
    {
        onGround = true;
        FindObjectOfType<AudioManager>().PlaySound("PlayerWalk");
        Debug.LogError("feet touches ground!");



    }
    private void OnCollisionExit(Collision collision)
    {
        onGround = false;
    }

    
}
