using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    void OnCollisionExit(Collision player) {
        if(player.gameObject.tag =="Player")
        {
            Invoke("RemovePlatform", 3.0f);
        }
        
    }

    void RemovePlatform(){
        this.gameObject.SetActive(false);
    }
}
