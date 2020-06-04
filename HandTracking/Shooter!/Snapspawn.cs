using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snapspawn : MonoBehaviour
{
    public Gesturedetector rightGestures;
    public OVRSkeleton skeleton;
    private List<OVRBone> fingerBones;

    public GameObject toSpawn;

    bool pt1 = false;

    // Update is called once per frame
    void Update()
    {
        string gestureName = rightGestures.getCurrentGesture();

        if (gestureName == "SnapPt1")
        {
            pt1 = true;
        }
        if (pt1 && gestureName == "SnapPt2")
        {
            var fingerBones = new List<OVRBone>(skeleton.Bones);
            OVRBone fingerTip = fingerBones[20];

            Instantiate(toSpawn);
            pt1 = true;
        }
        else
        {
            pt1 = false;
        }
    }
}
