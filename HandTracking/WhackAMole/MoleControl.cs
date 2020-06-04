using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoleControl : MonoBehaviour
{

    [SerializeField]
    GameObject moleInstance;

    public float heightTracker;
    public int xTracker = 0;
    public float xInc;
    public float heightInc = 0;

    public Vector3 baseHeight;

    private void Start()
    {
        baseHeight = moleInstance.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.M))
        {
            TextMeshPro squishedVal = GameObject.Find("Counter Value").GetComponent<TextMeshPro>();
            int score = int.Parse(squishedVal.text);
            score++;
            squishedVal.text = score.ToString();
        }
        //bounce, up and down
        if (heightTracker > 360)
        {
            heightTracker = 0;
        }
        heightInc = Mathf.Sin(heightTracker / 10);
        heightTracker += 0.1f;

        //actually move the object
        Vector3 newHeight = baseHeight + new Vector3(0, heightInc / 10, 0);
        moleInstance.transform.position = newHeight;
    }

    private void OnTriggerEnter(Collider collision)
    {
        TextMeshPro squishedVal = GameObject.Find("Counter Value").GetComponent<TextMeshPro>();
        int score = int.Parse(squishedVal.text);
        score++;
        squishedVal.text = score.ToString();
    }
}
