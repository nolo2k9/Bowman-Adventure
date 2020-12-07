using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenerateLevel : MonoBehaviour
{
    public static GameObject dummyTraveller;

    public static GameObject lastPlatform;

    public void ExitToMenu(){
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    void Awake()
    {
        //create dummy gameObject
        dummyTraveller = new GameObject("dummy");
    }

    public static void RunDummy()
    {
        GameObject p = Pool.singelton.GetRandom();
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
             if (lastPlatform.tag == "Split Platform")
                //move dummy forward by 20 from last platform
                dummyTraveller.transform.position =
                    lastPlatform.transform.position +
                    PlayerController.player.transform.forward * 15;
            else

            if (lastPlatform.tag == "stairs")
            {
                dummyTraveller.transform.Translate(0, 5, 0);
            }
        }
        lastPlatform = p;
        p.SetActive(true);
        p.transform.position = dummyTraveller.transform.position;
        p.transform.rotation = dummyTraveller.transform.rotation;

        if (p.tag == "downStairs")
        {
            dummyTraveller.transform.Translate(0, -5, 0);
            p.transform.Rotate(0, 180, 0);
            p.transform.position = dummyTraveller.transform.position;
        }
    }
}
