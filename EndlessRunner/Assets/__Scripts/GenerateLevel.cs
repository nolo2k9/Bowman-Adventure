using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
This class handles the genertaion of platforms in the world. 
The dummy travels ahead of the player and generates platforms when it reaches a certain point.
*/
public class GenerateLevel : MonoBehaviour
{
    //DummyTraveller gameObject
    public static GameObject dummyTraveller;
    //previous platform gameobject
    public static GameObject lastPlatform;

    //method to exit to main menu scene
    public void ExitToMenu(){
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    //initialise dummy gameobject on awake
    void Awake()
    {
        //create dummy gameObject
        dummyTraveller = new GameObject("dummy");
    }

    public static void RunDummy()
    {
        //initialise the pool
        GameObject p = Pool.singelton.GetRandom();
        //if pool is empty return
        if (p == null) return;

        if (lastPlatform != null)
        {
            if (lastPlatform.tag == "T-Junction")
                //move dummy forward by 20 from last platform
                dummyTraveller.transform.position =
                    lastPlatform.transform.position +
                    PlayerController.player.transform.forward * 20;
            else
                //move dummy forward by 10 from last platform
                dummyTraveller.transform.position =
                    lastPlatform.transform.position +
                    PlayerController.player.transform.forward * 10;

                
        }
        //last platform
        lastPlatform = p;
        //activate platform
        p.SetActive(true);
        //position rotation of p
        p.transform.position = dummyTraveller.transform.position;
        p.transform.rotation = dummyTraveller.transform.rotation;

    }
}
