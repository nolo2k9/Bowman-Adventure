using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Data : MonoBehaviour
{
    public static Data singleton;
    public Text textScore = null;
    

    public int score = 0;
    //private Scroll sc;

    

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
        PlayerPrefs.SetInt("score", 0);
    }

    public void ScoreUpdate(int s){
        //score updates to 5 for each coin
        score += s;
        //carrying score through deaths
        PlayerPrefs.SetInt("score", score);
        //if the score isnt null print the score
        if(textScore != null){
            textScore.text = "Score: " + score;
        }

        

    }
}
