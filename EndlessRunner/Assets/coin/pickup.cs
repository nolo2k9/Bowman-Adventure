using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        //if the entity colliding is the player
        if (other.gameObject.tag == "Player")
        {
            //Assinging 5 points per coin
            Data.singleton.ScoreUpdate(5);
            //Play the sound in the first position of array
            PlayerController.sounds[1].Play();

            //destory coin
            Destroy(this.gameObject);
        }
    }
}
