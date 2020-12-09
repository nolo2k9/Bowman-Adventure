using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    //array of mesh rendererd
    MeshRenderer[] mesh;

    void Start()
    {
        mesh = this.GetComponentsInChildren<MeshRenderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
    
            //Assinging 5 points per coin
            Data.singleton.ScoreUpdate(5);

            //disable coin
            foreach (MeshRenderer m in mesh)
            {
                m.enabled = false;
            }
        }
    }

    void OnEnable()
    {
        {
            if (mesh != null)
            {
                //reenable coin
                foreach (MeshRenderer m in mesh)
                {
                    m.enabled = true;
                }
            }
        }
    }
}
