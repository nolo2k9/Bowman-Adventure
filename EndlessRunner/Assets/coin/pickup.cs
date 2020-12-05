using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Assinging 5 points per coin
            Data.singleton.ScoreUpdate(5);

            //destory coin
            Destroy(this.gameObject);
        }
    }
}
