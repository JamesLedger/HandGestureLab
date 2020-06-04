using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public Transform relativeTo;

    public Vector3 direction;
    int deathCounter = 0;

    private void Start()
    {
        GameObject handBase = GameObject.Find("RightHandAnchor");
        direction = gameObject.transform.position - relativeTo.position;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0.1f,0.1f,0.1f), 10);
        gameObject.transform.position += direction;       
    }
}
