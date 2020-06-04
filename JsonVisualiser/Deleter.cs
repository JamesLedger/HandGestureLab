using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deleter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Google")
        {
            GameObject[] points;
            points = GameObject.FindGameObjectsWithTag("googleData");
            foreach (GameObject point in points)
            {
                Destroy(point);
            }
            var spawnPoint = GameObject.Find("GoogleSpawn");
            collision.gameObject.transform.position = spawnPoint.transform.position;
            collision.gameObject.transform.rotation = spawnPoint.transform.rotation;
        }

        if (collision.gameObject.name == "Apple")
        {
            GameObject[] points;
            points = GameObject.FindGameObjectsWithTag("appleData");
            foreach (GameObject point in points)
            {
                Destroy(point);
            }
            var spawnPoint = GameObject.Find("AppleSpawn");
            collision.gameObject.transform.position = spawnPoint.transform.position;
            collision.gameObject.transform.rotation = spawnPoint.transform.rotation;
        }

        if (collision.gameObject.name == "Microsoft")
        {
            GameObject[] points;
            points = GameObject.FindGameObjectsWithTag("microData");
            foreach (GameObject point in points)
            {
                Destroy(point);
            }
            var spawnPoint = GameObject.Find("MicrosoftSpawn");
            collision.gameObject.transform.position = spawnPoint.transform.position;
            collision.gameObject.transform.rotation = spawnPoint.transform.rotation;
        }

        if (collision.gameObject.name == "MyLove")
        {
            GameObject[] points;
            points = GameObject.FindGameObjectsWithTag("myLove");
            foreach (GameObject point in points)
            {
                Destroy(point);
            }
            var spawnPoint = GameObject.Find("myLoveSpawn");
            collision.gameObject.transform.position = spawnPoint.transform.position;
            collision.gameObject.transform.rotation = spawnPoint.transform.rotation;
        }


    }
}
