using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroll : MonoBehaviour
{
    public Text timer;

    public float speed;

    private float startTime;

    void Start()
    {
         //Time since application started
            startTime = Time.time;
    }

    void FixedUpdate()
    {
        float ti = startTime;
        float mins = ti / 60.0f;

        if (PlayerController.currentPlatform == null) return;
        if (PlayerController.currentPlatform.tag == "stairs")
        {
            this.transform.Translate(0, -0.08f, 0);
        }
        if (PlayerController.currentPlatform.tag == "downStairs")
        {
            this.transform.Translate(0, 0.08f, 0);
        }

       
            speed = -0.17f;
            this.transform.position +=
                PlayerController.player.transform.forward * speed;

            timer.text = "Speed 1" +"\n" + "Difficulty: Easy";

       
        
        Debug.Log (speed);

        //string seconds = (t % 60).ToString();
        if (PlayerController.dead) return;
    }
}
