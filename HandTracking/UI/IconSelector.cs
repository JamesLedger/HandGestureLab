using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus;
using OculusSampleFramework;
using TMPro;

public class IconSelector : MonoBehaviour
{
    [SerializeField]
    public GameObject[] icons;

    [SerializeField]
    public GameObject[] iconBases;

    [SerializeField]
    public static int selectedButton;

    [SerializeField]
    public Transform[] teleportLocations;

    [SerializeField]
    GameObject player;

    int lastButton;
    Vector3 lastPosition;
    bool activated;

    int teleportTracker = 100;

    private void Start()
    {
        activated = false;
    }

    public int getSelectedButton()
    {
        return selectedButton;
    }


    public void incrementButton()
    {
        if (selectedButton < 3)
        {
            selectedButton++;
        }
        else
        {
            selectedButton = 0;
        }
    }

    public void makeSelection()
    {
            player.transform.position = teleportLocations[selectedButton].position;
            teleportTracker = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TextMeshPro selectedButtonOption = GameObject.Find("SelectedButtonValue").GetComponent<TextMeshPro>();
        selectedButtonOption.text = selectedButton.ToString();

        Gesturedetector detector = GetComponent<Gesturedetector>();
        string currentGesture = detector.getCurrentGesture();
        if (currentGesture == "LeftThumbsUp" && activated)
        {
            player.transform.position = teleportLocations[selectedButton].position;
            teleportTracker = 0;
        }
        else if(currentGesture == "LeftUiclose")
        {
            activated = false;
        }


        if (selectedButton != lastButton)
        {
            activated = false;
        }

        for (int i = 0; i < 4; i++)
        {
            if (i == selectedButton)
            {
                if (!activated)
                {
                    var newPos = icons[i].transform.position + new Vector3(0f, -0.02f, 0f);
                    icons[i].transform.position = newPos;
                    activated = true;
                }
            }
            else
            {
                icons[i].transform.position = iconBases[i].transform.position;
            }
        }
        lastButton = selectedButton;
        teleportTracker++;
    }
}
