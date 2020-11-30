using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    //List containing audioSource items
    List<AudioSource> sounds = new List<AudioSource>();

    // Start is called before the first frame update
    public void Start()
    {
        //AudioSource array being set to a game object with the tag Data and getting the audio source components from that GameObject
        AudioSource[] audioSources =
            GameObject
                .FindWithTag("Data")
                .GetComponentsInChildren<AudioSource>();

        //adding the sound elements to the list
        for (int i = 1; i < audioSources.Length; i++)
        {
            sounds.Add(audioSources[i]);
        }

        // assigning variable to Slider component
        Slider soundSlider = this.GetComponent<Slider>();

        //if Player Prefs has a key soundLevel
        if (PlayerPrefs.HasKey("soundLevel"))
        {
            //set the value to the one associated with soundLevel
            soundSlider.value = PlayerPrefs.GetFloat("soundLevel");
            UpdateSoundVolume(soundSlider.value);
        }
        else
        //if theres no soundSlider.value key
        {
            //set a default value of 1

            soundSlider.value = 1;
            UpdateSoundVolume(1);
        }
    }

    // Update is called once per frame
    public void UpdateSoundVolume(float value)
    {
        //set value for soundLevel in PlayerPrefs and passing it to value
        PlayerPrefs.SetFloat("soundLevel", value);

        //Loop through each audio source in the music list
        foreach (AudioSource s in sounds)
        {
            //volume = the assigned volume 0-1
            s.volume = value;
        }
    }
}
