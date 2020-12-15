using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This class handles pause menu.
*/
public class PauseMenu : MonoBehaviour
{
    //pauseMenu gameobject
    [SerializeField]
    private GameObject pauseMenu;

    //boolean isPaused
    [SerializeField]
    private bool isPaused;

    // Update is called once per frame
    void Update()
    {
        //if p is pressed
        if (Input.GetKeyDown(KeyCode.P))
        {
            //change the current value of isPaused
            isPaused = !isPaused;
        }
        if (isPaused)
        {
            //if isPaused is true activate the menu
            ActivateMenu();
        }
        else
        {
            //if isPuased is false de-activate the menu
            DeactivateMenu();
        }
    }

    void ActivateMenu()
    {
        //time is 0
        Time.timeScale = 0;

        //activate menu
        pauseMenu.SetActive(true);
    }

    public void DeactivateMenu()
    {
        //time back to regular time
        Time.timeScale = 1;

        //menu is false
        pauseMenu.SetActive(false);
    }
}
