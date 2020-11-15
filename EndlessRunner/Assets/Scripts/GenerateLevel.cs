using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    

    GameObject dummy;

    void Start()
    {
        dummy = new GameObject("dummy");

        //Vector3 pos = new Vector3(0,0,0);
        for (int i = 0; i < 20; i++)
        {
           
            GameObject go = Pool.singelton.GetRandom();
            if(go ==null) return;
            go.SetActive(true);
            go.transform.position = dummy.transform.position;
            go.transform.rotation = dummy.transform.rotation;
            if (go.tag == "stairs")
            {
                dummy.transform.Translate(0, 5, 0);
            }
            else if (go.tag == "downStairs")
            {
                dummy.transform.Translate(0, -5, 0);
                go.transform.Rotate(new Vector3(0, 180, 0));
                go.transform.position = dummy.transform.position;
            }
            else if (go.tag == "T-Junction")
            {
                if (Random.Range(0, 2) == 0)
                    dummy.transform.Rotate(new Vector3(0, 90, 0));
                else
                    dummy.transform.Rotate(new Vector3(0, -90, 0));

                dummy.transform.Translate(Vector3.forward * -10);
            }
            dummy.transform.Translate(Vector3.forward * -10);
        }
    }
}
