﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait2Seconds : MonoBehaviour
{

    float timer = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer%60 <= 0f)
            ScenesManager.LoadScene2();
    }
}
