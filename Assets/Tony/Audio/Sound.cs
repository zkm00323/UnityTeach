using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable] //CUSTOM CLASS needs to be serializable or else it won't show up in inspector
public class Sound  //lists of sounds
{
    public string name;
    public AudioClip clip;

    [Range(0f,1f)]
    public float volume;

    [Range(0.1f, 3f)]
    public float pitch;

    public bool loop;
    
    [HideInInspector] //is public but won't show on inspector 
    public AudioSource source;
}
