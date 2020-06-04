using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{

    [SerializeField]
    GameObject follower;

    public OVRSkeleton skeleton;
    private List<OVRBone> fingerBones;

    [SerializeField]
    float xOffset = 0f;

    [SerializeField]
    float yOffset = 0f;

    [SerializeField]
    bool active;

    [SerializeField]
    int bone = 0;

    bool trackHand;
    int incrementTracker;

    private void Start()
    {
        follower.SetActive(false);
        trackHand = false;
        incrementTracker = 100;
    }

    // Update is called once per frame
    void Update()
    {

        if (trackHand == true)
        {
            if (follower.activeSelf)
            {
                fingerBones = new List<OVRBone>(skeleton.Bones);
                var offset = new Vector3(xOffset, yOffset, 0f);
                OVRBone thumbtip = fingerBones[bone];
                var transformedCoords = thumbtip.Transform.position + offset;
                follower.transform.position = transformedCoords;
            }
        }

        Gesturedetector detector = GetComponent<Gesturedetector>();

        if (detector != null)
        {
            string currentGesture = detector.Recognise().name;

            if (currentGesture == "LeftUiOpen")
            {
                follower.SetActive(true);
                trackHand = true;
            }
            else if (currentGesture == "LeftUiClose")
            {
                follower.SetActive(false);
                trackHand = false;
            }
            else if (currentGesture == "LeftUiIncrement")
            {
                if (incrementTracker >= 30)
                {
                    IconSelector selector = gameObject.AddComponent<IconSelector>();
                    selector.incrementButton();
                    incrementTracker = 0;
                }
            }
        }
       

        incrementTracker++;
    }
}
