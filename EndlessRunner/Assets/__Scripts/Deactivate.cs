using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This class is used to deactivate platforms a few seconds after the player has collided with them. 
*/
public class Deactivate : MonoBehaviour
{
    //control variable 
    bool dScheduled = false;

    void OnCollisionExit(Collision player) {
        //if the player has collided and dScheduled = false
        if(player.gameObject.tag =="Player" && !dScheduled)
        {
            //remove the platform after 5 seconds
            Invoke("RemovePlatform", 5.0f);
            dScheduled = true;
        }
        
    }

    void RemovePlatform(){
        //set platform active to false
        this.gameObject.SetActive(false);
        //return dScheduled to false
        dScheduled = false;
    }
}
