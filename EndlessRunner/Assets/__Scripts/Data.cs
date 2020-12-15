using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
This class handles the player score behaviour. 
*/
public class Data : MonoBehaviour
{
    //Ensure lass has only a single globally accessible instance available at all times
    public static Data singleton;
    //Text
    public Text textScore = null;

    int score = 0;
     void Awake() {
        //GameObject array to find all game objects with the given tag
        GameObject[] gameData = GameObject.FindGameObjectsWithTag("Data");

        //if the array is greater than 1 destory the new one.
        if(gameData.Length > 1){

            Destroy(this.gameObject);
        }
        //Don't destory between scenes
        DontDestroyOnLoad(this.gameObject);
        //this instance of singleton
        singleton = this;
        //Set player score to 0 initially
        PlayerPrefs.SetInt("score", 0);
    }

    public void ScoreUpdate(int s){
        //score updates to 5 for each coin
        score += s;
        //carrying score through deaths
        PlayerPrefs.SetInt("score", score);
        //if the score isnt null print the score
        if(textScore != null){
            //Output
            textScore.text = "Score: " + score;
        }

    }
}
