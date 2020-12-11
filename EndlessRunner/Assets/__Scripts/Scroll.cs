using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Scroll : MonoBehaviour
{

    public Text message;

    void FixedUpdate()
    {
        if(PlayerController.dead)return;
        this.transform.position +=
            PlayerController.player.transform.forward * -0.15f;

        if(PlayerPrefs.GetInt("score") > 1000 && PlayerPrefs.GetInt("score") < 2000){
            this.transform.position +=
            PlayerController.player.transform.forward * -0.16f /2;
            message.text = "Speed increase" + "\n" + "Think Faster";

        }else if(PlayerPrefs.GetInt("score") > 2000 ){
            this.transform.position +=
            PlayerController.player.transform.forward * -0.18f;
            message.text = "Speed increase Sick Mode";
        }
        if (PlayerController.currentPlatform == null) return;
        
    }
}