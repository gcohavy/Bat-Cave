﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveRepeat : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth = 30;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < startPos.z - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
