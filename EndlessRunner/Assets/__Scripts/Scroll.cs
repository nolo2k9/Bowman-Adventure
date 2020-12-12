using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroll : MonoBehaviour
{
    GUIStyle myStyle = new GUIStyle();

    public Text message;

    public Material[] skyboxes;

    private void Start()
    {
        ChangeMySkybox();
    }

    void FixedUpdate()
    {
        if (PlayerController.dead) return;
        this.transform.position +=
            PlayerController.player.transform.forward * -0.15f;

        if (
            PlayerPrefs.GetInt("score") > 1000 &&
            PlayerPrefs.GetInt("score") < 2000
        )
        {
            this.transform.position +=
                PlayerController.player.transform.forward * -0.16f / 2;
            message.text = "Think Faster";

            DynamicGI.UpdateEnvironment();
        }
        else if (PlayerPrefs.GetInt("score") > 2000)
        {
            this.transform.position +=
                PlayerController.player.transform.forward * -0.18f;
          
            message.text = "Sick Mode";
        }
        if (PlayerController.currentPlatform == null) return;
    }

    void OnGUI()
    {
        GUI.color = Color.red;
        GUI.skin.box.fontSize = GUI.skin.button.fontSize = 29;

        if (PlayerPrefs.GetInt("score") < 1000)
        {
            GUI.Label(new Rect(10, 10, 100, 1000), "Easy");
            
        }
        else if (
            PlayerPrefs.GetInt("score") > 1000 &&
            PlayerPrefs.GetInt("score") < 2000
        )
        {
            GUI.Label(new Rect(10, 10, 100, 1000), "Medium");
            
        }
        else if (PlayerPrefs.GetInt("score") > 2000)
        {
            GUI.Label(new Rect(10, 10, 100, 1000), "Hard");
        }
    }

    void ChangeMySkybox()
    {
        int x = Random.Range(0, skyboxes.Length);

        RenderSettings.skybox = skyboxes[x];
        
        if (PlayerPrefs.GetInt("score") > 1000 && PlayerPrefs.GetInt("score") < 2000)
        {  
            RenderSettings.skybox = skyboxes[x];
        }
        else if(PlayerPrefs.GetInt("score") > 2000)
        {
            RenderSettings.skybox = skyboxes[x];
        }
    }
}
