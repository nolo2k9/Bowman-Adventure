using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
    // Players Previous Score
    public Text lastScore;
    //Highscore
    public Text highestScore;

    void OnEnable() {
        //if PlayerPrefs contains a score
        if(PlayerPrefs.HasKey("lastScore")){
            //setting the previous score to be the last score saved in PlayerPrefs
            lastScore.text = "Last Score: " + PlayerPrefs.GetInt("lastScore");

        }else{
            //otherwise the last score is set to 0
            lastScore.text = "Last Score: 0 ";
        }
         //if PlayerPrefs contains a score
        if(PlayerPrefs.HasKey("highscore")){
            //setting the previous score to be the last score saved in PlayerPrefs
            highestScore.text = "Highscore: " + PlayerPrefs.GetInt("highscore");

        }else{
            //otherwise the last score is set to 0
            highestScore.text = "Highscore: 0 ";
        }
         
        

        
    }


}
