using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/*
This class handles the button functionality for the main menu
*/
public class MenuController : MonoBehaviour
{
    //main array
    GameObject[] main;
    //panels array
    GameObject[] panels;
    //max health variable
    int maxHealth = 3;

    void Start()
    {
        //putting all the items with the tag Windows into an array
        panels = GameObject.FindGameObjectsWithTag("Windows");
        //putting all the items with the tag Main into an array
        main = GameObject.FindGameObjectsWithTag("Main");
        //Deactivate all panels
        foreach (GameObject pan in panels)
        {
            pan.SetActive(false);
        }
    }

    public void CloseWindow(Button button)
    {
        //buttons gameobjects transform the parent transform its attached to set to false
        button.gameObject.transform.parent.gameObject.SetActive(false);
        //re-activate the main menu buttons
        foreach (GameObject but in main)
        {
            but.SetActive(true);
        }
    }

    public void openWindow(Button button)
    {
        //buttons gameobjects transform the first child of that objects transform is set to true
        button.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        //de-activate the main menu buttons
        foreach (GameObject but in main)
        {
            if (but != button.gameObject) 
                but.SetActive(false);
        }
    }

    public void LoadNewScene()
    {
        //set lives to 3
        PlayerPrefs.SetInt("lives", maxHealth);
        //load main scene
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
    //quit the application
    public void EndGame()
    {
        Application.Quit();
    }
    //if escape is pressed the game quits
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            EndGame();
        }
    }
}
