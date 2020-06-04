using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class SpawnData : MonoBehaviour
{
    [SerializeField]
    Vector3 StartPoint;

    [SerializeField]
    GameObject DataPoint;

    [SerializeField]
    int dataPointCount;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject dataPointRef;

        if (collision.gameObject.name == "Random")
        {
            
        }

        if (collision.gameObject.name == "Sine")
        {
            for (double i = 0f; i < 10f; i += 0.1)
            {
                dataPointRef = Instantiate(DataPoint, StartPoint + new Vector3(0, Mathf.Sin((float)i), (float)i), Quaternion.identity);
                dataPointRef.tag = "data";
            }
        }

        if (collision.gameObject.name == "Reset")
        {
            var gameObjects = GameObject.FindGameObjectsWithTag("data");

            foreach (var item in gameObjects)
            {
                Destroy(item);
            }
        }



    }

}
