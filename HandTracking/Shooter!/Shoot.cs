using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject bullet;

    public Gesturedetector rightGestures;
    public OVRSkeleton skeleton;
    private List<OVRBone> fingerBones;

    public IconSelector selectorInstance;

    [SerializeField]
    float yOffset = 0.2f;

    [SerializeField]
    float zOffset = 0.2f;

    int counter = 0;
    bool loaded = false; 



    // Update is called once per frame
    void Update()
    {
        int button = selectorInstance.getSelectedButton();

        if (button == 3)
        {
            string gestureName = rightGestures.getCurrentGesture();

            if (gestureName == "GunShoot" && counter == 50 && loaded == true)
            {
                var fingerBones = new List<OVRBone>(skeleton.Bones);
                OVRBone fingerTip = fingerBones[8];

                var offset = new Vector3(0f, yOffset, zOffset);

                Vector3 spawnPos = fingerTip.Transform.position;
                spawnPos += offset;
                Quaternion rotatation = new Quaternion(0f, 0f, 0f, 0f);

                Instantiate(bullet, spawnPos, rotatation);
                counter = 0;
                loaded = false;
            }
            else if (gestureName == "GunCock")
            {
                loaded = true;
            }


            if (counter < 50)
            {
                counter++;
            }
        }
       
    }
}
