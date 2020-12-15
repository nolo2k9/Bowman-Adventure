using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    This class handles the moving platforms, the skybox changing, the difficulty of the game.
*/
public class Scroll : MonoBehaviour
{
    //Text
    public Text message;
    //array of skyboxes
    public Material[] skyboxes;
    //sixe of font
    private int fontSize = 28;

    private void Start()
    {
        //eachtime start is called change the skybox
        ChangeMySkybox();
    }

    void FixedUpdate()
    {
        //if player is dead return
        if (PlayerController.dead) return;
        //set players position * by speed
        this.transform.position +=
            PlayerController.player.transform.forward * -0.15f;
        //if score is > 1000 and <2000
        if (
            PlayerPrefs.GetInt("score") > 1000 &&
            PlayerPrefs.GetInt("score") < 2000
        )
        {
            //increase the players speed
            this.transform.position +=
                PlayerController.player.transform.forward * -0.16f / 2;
            //change message
            message.text = "Think Faster";
    
        }//if score is > 2000
        else if (PlayerPrefs.GetInt("score") > 2000)
        {
            //increase the players speed
            this.transform.position +=
                PlayerController.player.transform.forward * -0.18f;
             //change message
            message.text = "Sick Mode";
        }
        //if platform is null return
        if (PlayerController.currentPlatform == null) return;
    }

    void OnGUI()
    {
        //colour of text
        GUI.color = Color.red;
        //setting fontsize
        GUI.skin.label.fontSize = GUI.skin.box.fontSize = GUI.skin.button.fontSize = fontSize;
        //if score is less than 1000 display easy difficulty
        if (PlayerPrefs.GetInt("score") < 1000)
        {
            GUI.Label(new Rect(10, 10, 100, 1000), "Easy");
            
        }
          //if score is greater than 1000 and less than 2000 display Medium difficulty
        else if (
            PlayerPrefs.GetInt("score") > 1000 &&
            PlayerPrefs.GetInt("score") < 2000
        )
        {
            GUI.Label(new Rect(10, 10, 100, 1000), "Medium");
            
        }
        //if score is greater than 2000 display Hard difficulty
        else if (PlayerPrefs.GetInt("score") > 2000)
        {
            GUI.Label(new Rect(10, 10, 100, 1000), "Hard");
        }
    }

    void ChangeMySkybox()
    {
        //set x to randomise skyboxes
        int x = Random.Range(0, skyboxes.Length );
        //update skybox accorrding to skybox chosen
        RenderSettings.skybox = skyboxes[x];
        //change skybox accoring to player score
        if (PlayerPrefs.GetInt("score") > 1000 && PlayerPrefs.GetInt("score") < 2000)
        {  
            RenderSettings.skybox = skyboxes[x];
        }
        else if(PlayerPrefs.GetInt("score") > 2000)
        {
            RenderSettings.skybox = skyboxes[x];
        }
    }
}
