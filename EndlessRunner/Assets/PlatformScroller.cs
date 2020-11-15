﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScroller : MonoBehaviour
{
    void FixedUpdate()
    {
        this.transform.position +=
            PlayerController.player.transform.forward * -0.1f;

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
