using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Data : MonoBehaviour
{
    public static Data singleton;
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
    }

    public void ScoreUpdate(int s){
        score += s;
        if(textScore != null){
            textScore.text = "Score: " + score;
        }

    }
}
