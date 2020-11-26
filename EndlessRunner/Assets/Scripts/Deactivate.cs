using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    bool dScheduled = false;
    void OnCollisionExit(Collision player) {
        if(player.gameObject.tag =="Player" && !dScheduled)
        {
            Invoke("RemovePlatform", 5.0f);
            dScheduled = true;
        }
        
    }

    void RemovePlatform(){
        this.gameObject.SetActive(false);
        dScheduled = false;
    }
}
