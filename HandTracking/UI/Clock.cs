using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Clock : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        TextMeshPro gestureContent = GameObject.Find("Clock").GetComponent<TextMeshPro>();
        gestureContent.text = System.DateTime.Now.ToShortTimeString();
    }
}
