﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {

        if(other.gameObject.tag =="Player"){
            Debug.Log("Pick-up");
            Destroy(this.gameObject);
        }
        
    }
}
