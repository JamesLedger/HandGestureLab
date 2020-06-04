using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GestureWriter : MonoBehaviour
{

    [SerializeField]
    GameObject leftGestures;
    [SerializeField]
    GameObject rightGestures;

    // Update is called once per frame
    void Update()
    {
        string gestureName = "";

        try
        {
            gestureName = leftGestures.GetComponent<Gesturedetector>().getCurrentGesture();
        }
        catch (System.Exception)
        {
            gestureName = "";
        }
      
        TextMeshPro gestureContent = GameObject.Find("Left Gesture Value").GetComponent<TextMeshPro>();
        gestureContent.text = gestureName;
    }
}
