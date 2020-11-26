using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreRegister : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Data.singleton.textScore = this.GetComponent<Text>();
    }

   
}
