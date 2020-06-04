using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetectPos : MonoBehaviour
{

    public TextMeshPro posBoard;

    // Start is called before the first frame update
    void Start()
    {
        posBoard = FindObjectOfType<TextMeshPro>();
        posBoard.text = "Hello world!";
    }

    // Update is called once per frame
    void Update()
    {
        var rightHand = GameObject.Find("RightHandAnchor");

        float x = rightHand.transform.position.x;
        float y = rightHand.transform.position.y;
        float z = rightHand.transform.position.z;

        string boardText = "Position \nX : " + toCoord(x) + "\nY : " + toCoord(y) + "\nZ : " + toCoord(z);

        posBoard.text = boardText;
    }

    public string toCoord(float input)
    {
        string output = "";

        input = input * 100;
        input = Mathf.Round(input);
        input = input / 100;
        output = (input).ToString();

        return output;

    }
}
