using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSynth : MonoBehaviour
{
    [SerializeField]
    public float gain;

    [SerializeField]
    public double frequency = 440.0;

    [SerializeField]
    public float volume = 0.1f;

    [SerializeField]
    public float[] frequencies;
    public int thisFreq;

    private double increment;
    private double phase;
    private double sampling_frequency = 48000.0f;


    private void Start()
    {
        frequencies = new float[8];
        frequencies[0] = 440;
        frequencies[1] = 494;
        frequencies[2] = 554;
        frequencies[3] = 587;
        frequencies[4] = 659;
        frequencies[5] = 740;
        frequencies[6] = 831;
        frequencies[7] = 880;
    }

    // Update is called once per frame
    void Update()
    {
        // A Pressed
        if (OVRInput.Get(OVRInput.Button.One))
        {
            var rightHand = GameObject.Find("RightHandAnchor");

            float rawX = rightHand.transform.position.x;
            float rawY = rightHand.transform.position.y;
            float rawZ = rightHand.transform.position.z;

            gain = volume * GetVolume(rawZ);
            frequency = GetFreq(rawX);
        }
        else
        {
            gain = 0;
        }
    }

    private float GetVolume(float rawY)
    {
        rawY = rawY * 100;
        rawY = Mathf.Round(rawY);
        rawY = rawY / 100;

        int counter = 0;
        while (rawY > 0)
        {
            rawY -= 0.1f;
            counter++;
        }

        return counter/10;

    }

    private int GetFreq(float rawX)
    {
        if (rawX < 0)
        {
            rawX = rawX * -1;
        }

        rawX = rawX * 100;
        rawX = Mathf.Round(rawX);
        rawX = rawX / 100;

        int counter = 0;
        while (rawX > 0 )
        {
            rawX -= 0.1f;
            counter++;
        }

        int freq = 440 + (counter * 100);

        return freq;
    }

    private void OnAudioFilterRead(float[] data, int channels)
    {
        increment = frequency * 2 * Mathf.PI / sampling_frequency;

        for (int i = 0; i < data.Length; i += channels)
        {
            phase += increment;
            data[i] = (float)(gain * Mathf.Sin((float)phase));

            if (channels == 2)
            {
                data[i + 1] = data[i];
            }

            if (phase > (Mathf.PI * 2))
            {
                phase = 0.0f;
            }


        }
    }


}
