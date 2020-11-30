using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        // assigning variable to Slider component
        Slider musSlider = this.GetComponent<Slider>();
        //if Player Prefs has a key musicLevel
        if(PlayerPrefs.HasKey("musicLevel"))
        {   //set the value to the one associated with musicLevel
            musSlider.value = PlayerPrefs.GetFloat("musicLevel");
            UpdateVolume(musSlider.value);

        }
        //if theres no musSlider.value key
        else{
            //set a default value of 1 
            musSlider.value = 1;
            UpdateVolume(1);
            
        }


    }

    // Update is called once per frame
   public void UpdateVolume(float value)
    {   //set value for musicLevel in PlayerPrefs and passing it to value
        PlayerPrefs.SetFloat("musicLevel", value);
        //Loop through each audio source in the music list
        foreach(AudioSource mus in music){
            //volume = the assigned volume 0-1
            mus.volume = value;
        }
        
    }
}
