using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
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

    private void OnCollisionEnter(Collision collision)
    {
        gain = volume;
        frequency = frequencies[thisFreq];
        thisFreq++;
        thisFreq = thisFreq % frequencies.Length;
    }

    private void OnCollisionExit(Collision collision)
    {
        gain = 0;
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
