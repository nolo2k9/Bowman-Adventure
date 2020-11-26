using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreRegister : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Score in the game panel
        Data.singleton.textScore = this.GetComponent<Text>();
        //Update display to score text
        Data.singleton.ScoreUpdate(0);
    }

   
}
