using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    GameObject[] main;

    GameObject[] panels;

    void Start()
    {
        panels = GameObject.FindGameObjectsWithTag("Windows");
        main = GameObject.FindGameObjectsWithTag("Main");

        foreach (GameObject pan in panels)
        {
            pan.SetActive(false);
        }
    }

    public void CloseWindow(Button button)
    {
        Debug.Log("Cllicked");
        button.gameObject.transform.parent.gameObject.SetActive(false);
        foreach (GameObject but in main)
        {
            but.SetActive(true);
        }
    }

    public void openWindow(Button button)
    {
        button.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        foreach (GameObject but in main)
        {
            if (but != button.gameObject) 
                but.SetActive(false);
        }
    }

    public void LoadNewScene()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void EndGame()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            EndGame();
        }
    }
}
