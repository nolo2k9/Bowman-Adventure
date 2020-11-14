using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject[] platforms;

    void Start()
    {
       
       Vector3 pos = new Vector3(0,0,0);
       for (int i=0; i < 20; i++)
       {
           int platformNumber = Random.Range(0, platforms.Length);
           GameObject go = Instantiate(platforms[platformNumber],pos, Quaternion.identity);
         

           if(platforms[platformNumber].tag =="stairs")
           {
               pos.y +=5;
           }
           else if(platforms[platformNumber].tag =="downStairs")
           {
               pos.y -=5;
               go.transform.Rotate(new Vector3(0, 180, 0));
               go.transform.position = pos;

           }
           pos.z -=10;
           
       }
    }

}
