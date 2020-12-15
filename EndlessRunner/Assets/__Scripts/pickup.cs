using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
This class handles the picking up of coins.
*/
public class pickup : MonoBehaviour
{
    //array of mesh rendererd
    MeshRenderer[] mesh;

    void Start()
    {
        //get children of the mesh renderer
        mesh = this.GetComponentsInChildren<MeshRenderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        //if player collides with object
        if (other.gameObject.tag == "Player")
        {
    
            //Assinging 5 points per coin
            Data.singleton.ScoreUpdate(5);
            //play coin sound
            PlayerController.sfx[1].Play();

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
