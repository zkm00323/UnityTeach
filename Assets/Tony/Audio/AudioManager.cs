using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour //attach to audio manager at intro and has array of sound
{
    public Sound[] sounds;
    void Awake() //loop for the list and for each sound and add audio source
    {
        foreach(Sound s in sounds)
        {
            s.source =gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    // Update is called once per frame
    public void PlaySound(string name) //can be access by other scrips; loop through the sound list and find the one with right name
    {

        Sound s = Array.Find(sounds, sound => sound.name == name);

        s.source.Play();
    }
}
