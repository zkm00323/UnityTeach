using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXLink : MonoBehaviour
{
    public void PlayStepSound()
    {
        FindObjectOfType<AudioManager>().PlaySound("PlayerWalk");
    }
}
