using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour
{
    static public GameObject dummy;
    static public GameObject prevPlatform;

    void Awake() {
        dummy = new GameObject("dummy");
    }
    
    public static void DummyRunner(){
        GameObject g = Pool.singelton.GetRandom();
        if(g == null) return;
        if(prevPlatform != null)
        {
            dummy.transform.position = prevPlatform.transform.position + PlayerController.player.transform.forward * 10;
            if(prevPlatform.tag == "stairs"){
                dummy.transform.Translate(0,5,0);
            }
        }
        prevPlatform = g;
        g.SetActive(true);
        g.transform.position = dummy.transform.position;
        g.transform.rotation = dummy.transform.rotation;

        if(g.tag =="downStairs"){
             dummy.transform.Translate(0,-5,0);
             g.transform.Rotate(0,180, 0);
             g.transform.position = dummy.transform.position;

        }

    }
}
