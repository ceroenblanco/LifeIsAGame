﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookToCam : MonoBehaviour
{
    Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        transform.LookAt(cam.transform.position);
    }
}
