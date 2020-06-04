using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public struct Gesture
{
    public string name;
    public List<Vector3> fingerData;
    public UnityEvent onRecognised;
}

public class Gesturedetector : MonoBehaviour
{
    public string Name;
    public float threshhold = 0.1f;
    public OVRSkeleton skeleton;
    public List<OVRBone> fingerBones;
    public List<Gesture> gestures;
    public bool debugMode = true;
    public Gesture previousGesture;
    public Gesture currentGesture;

    // Start is called before the first frame update
    void Start()
    {
        fingerBones = new List<OVRBone>(skeleton.Bones);
        previousGesture = new Gesture();
        Debug.Log("Started tracking");
    }

    // Update is called once per frame
    void Update()
    {
        fingerBones = new List<OVRBone>(skeleton.Bones);
        if (debugMode && Input.GetKeyDown(KeyCode.Space))
        { 
            Save();
            Debug.Log("starting");
        }

        currentGesture = Recognise();

        bool hasRecognised = !currentGesture.Equals(new Gesture());
        //check gesture change
        if (hasRecognised && !currentGesture.Equals(previousGesture))
        {
            Debug.Log("New Gesure Found : " + currentGesture.name);
            previousGesture = currentGesture;
            currentGesture.onRecognised.Invoke();
        }
    }

    void Save()
    {
        Gesture g = new Gesture();
        g.name = "New Gesture";
        List<Vector3> data = new List<Vector3>();

        foreach (var bone in fingerBones)
        {
            data.Add(skeleton.transform.InverseTransformPoint(bone.Transform.position));
        }
        g.fingerData = data;
        gestures.Add(g);
    }

    public Gesture Recognise()
    {
        float currentMin = Mathf.Infinity;
        foreach (var gesture in gestures)
        {
            float sumDistance = 0;
            bool isDiscarded = false;
            for (int i = 0; i < fingerBones.Count; i++)
            {
                Vector3 currentData = skeleton.transform.InverseTransformPoint(fingerBones[i].Transform.position);
                float distance = Vector3.Distance(currentData, gesture.fingerData[i]);
                if (distance > threshhold)
                {
                    isDiscarded = true;
                    break;
                }

                sumDistance += distance;
            }
            if (!isDiscarded && sumDistance < currentMin)
            {
                currentMin = sumDistance;
                currentGesture = gesture;

                TextMeshPro confidenceContent = GameObject.Find("ConfidenceValue").GetComponent<TextMeshPro>();

                try
                {
                    string confidenceString = (1 - sumDistance).ToString().Substring(0, 3) + "%";
                }
                catch (System.Exception)
                {
                    string confidenceString = (1 - sumDistance).ToString() + "%";
                }

                confidenceContent.text = sumDistance.ToString();
                TextMeshPro gestureContent = GameObject.Find("GestureName").GetComponent<TextMeshPro>();
                gestureContent.text = currentGesture.name;

                TextMeshPro leftGestureVal = GameObject.Find("Left Gesture Value").GetComponent<TextMeshPro>();
                gestureContent.text = currentGesture.name;
                TextMeshPro rightGestureVal = GameObject.Find("Right Gesture Value").GetComponent<TextMeshPro>();
                gestureContent.text = currentGesture.name;
            }
        }
        return currentGesture;
    }

    public string getCurrentGesture()
    {
        if (currentGesture.name != null)
        {
            return currentGesture.name;
        }
        else
        {
            return "noHand";
        }
        
    }
}
