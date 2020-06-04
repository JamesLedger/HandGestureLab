using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;


public class Visualise : MonoBehaviour
{

    public Vector3 StartPoint;
    public GameObject DataPoint;
    public int length;

    public List<float> googleData;
    public List<float> appleData;
    public List<float> microData;
    public List<float> myLove;

    // Start is called before the first frame update
    void Start()
    {
        using (StreamReader sr = new StreamReader("C:\\Users\\James Ledger\\Documents\\Unity\\2D platform test\\Data Lab\\Assets\\JsonVisualiser\\Data\\AJ Bell.txt"))
        {
            string line;
            // Read and display lines from the file until the end of
            // the file is reached.
            while ((line = sr.ReadLine()) != null)
            {
                googleData.Add(float.Parse(line));
            }
        }
        using (StreamReader sr = new StreamReader("C:\\Users\\James Ledger\\Documents\\Unity\\2D platform test\\Data Lab\\Assets\\JsonVisualiser\\Data\\apple.txt"))
        {
            string line;
            // Read and display lines from the file until the end of
            // the file is reached.
            while ((line = sr.ReadLine()) != null)
            {
                appleData.Add(float.Parse(line));
            }
        }

        using (StreamReader sr = new StreamReader("C:\\Users\\James Ledger\\Documents\\Unity\\2D platform test\\Data Lab\\Assets\\JsonVisualiser\\Data\\Microsoft.txt"))
        {
            string line;
            // Read and display lines from the file until the end of
            // the file is reached.
            while ((line = sr.ReadLine()) != null)
            {
                microData.Add(float.Parse(line));
            }
        }

        for (int i = 0; i < microData.Count; i++)
        {
            myLove.Add(i/2);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject dataPointRef;

        if (collision.collider.name == "Google")
        {
            for (int i = 0; i < googleData.Count; i += 1)
            {
                var randPos = Random.Range(0, 20) - 10;
                dataPointRef = Instantiate(DataPoint, StartPoint + new Vector3(0, googleData[i] / 10, (float)i / 20 * -1), Quaternion.identity);
                dataPointRef.tag = "googleData";
                var rend = dataPointRef.GetComponent<Renderer>().material.color = Color.red;
            }
        }

        if (collision.collider.name == "Apple")
        {
            for (int i = 0; i < appleData.Count; i += 1)
            {
                var randPos = Random.Range(0, 20) - 10;
                dataPointRef = Instantiate(DataPoint, StartPoint + new Vector3(0, appleData[i] / 10, (float)i / 20 * -1), Quaternion.identity);
                var rend = dataPointRef.GetComponent<Renderer>().material.color = Color.blue;
                dataPointRef.tag = "appleData";
            }
        }

        if (collision.collider.name == "Microsoft")
        {
            for (int i = 0; i < microData.Count; i += 1)
            {
                var randPos = Random.Range(0, 20) - 10;
                dataPointRef = Instantiate(DataPoint, StartPoint + new Vector3(0, microData[i] / 10, (float)i / 20 * -1), Quaternion.identity);
                dataPointRef.tag = "microData";
                var rend = dataPointRef.GetComponent<Renderer>().material.color = Color.yellow;
            }
        }
        if (collision.collider.name == "MyLove")
        {
            for (int i = 0; i < myLove.Count; i += 1)
            {
                var randPos = Random.Range(0, 20) - 10;
                dataPointRef = Instantiate(DataPoint, StartPoint + new Vector3(0, myLove[i] / 10, (float)i / 20 * -1), Quaternion.identity);
                dataPointRef.tag = "myLove";
                var rend = dataPointRef.GetComponent<Renderer>().material.color = Color.magenta;
            }
        }

    }


}
