using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    //List containing audioSource items
    List<AudioSource> music = new List<AudioSource>();
    // Start is called before the first frame update
    void Start()
    {
        //AudioSource array being set to a game object with the tag Data and getting the audio source components from that GameObject
        AudioSource[] audioSources = GameObject.FindWithTag("Data").GetComponentsInChildren<AudioSource>();
        //adding the 0 element to the list
        music.Add(audioSources[0]);
    }

    // Update is called once per frame
   public void UpdateVolume(float value)
    {
        //Each audio source in the music list
        foreach(AudioSource mus in music){
            //volume = the assigned volume 0-1
            mus.volume = value;
        }
        
    }
}
