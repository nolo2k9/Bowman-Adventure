﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScroller : MonoBehaviour
{
        void FixedUpdate() {
        this.transform.position += PlayerController.player.transform.forward * -0.1f;
       
    }
}
