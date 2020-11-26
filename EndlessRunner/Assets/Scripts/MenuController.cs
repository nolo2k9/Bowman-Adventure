using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void LoadNewScene(){
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void EndGame()
    {
        Application.Quit();
    }

    void Update(){
        if(Input.GetKey("escape")){
            EndGame();
        }
    }

    
}
