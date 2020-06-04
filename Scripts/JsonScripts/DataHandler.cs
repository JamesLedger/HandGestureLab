using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string content = "";

        for (int i = 0; i < 200; i++)
        {
            var randomInt = Random.Range(0, 20);
            DataObjects.testInt.Add(randomInt - 10);
            content += (randomInt - 10).ToString();
        }

        TextMeshPro text = GetComponent<TextMeshPro>();
        text.SetText(content);

    }
}
