using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    void FixedUpdate()
    {
        if(PlayerController.dead)return;
        this.transform.position +=
            PlayerController.player.transform.forward * -0.15f;

        if (PlayerController.currentPlatform == null) return;
        if (PlayerController.currentPlatform.tag == "stairs")
        {
            this.transform.Translate(0, -0.06f, 0);
        }
        if (PlayerController.currentPlatform.tag == "downStairs")
        {
            this.transform.Translate(0, 0.06f, 0);
        }
    }
}
