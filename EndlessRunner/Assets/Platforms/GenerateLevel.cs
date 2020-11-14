using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject[] platforms;

    void Start()
    {
       
       Vector3 position = new Vector3(0,0,0);
       for (int i=0; i < 20; i++)
       {
           int platformNumber = Random.Range(0, platforms.Length);
           Instantiate(platforms[platformNumber],position, Quaternion.identity);
           position.z +=10;
       }
    }

}
