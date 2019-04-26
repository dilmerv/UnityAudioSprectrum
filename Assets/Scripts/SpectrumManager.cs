using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityLWRPEssentials.Assets.Scripts.Core;

public class SpectrumManager : MonoBehaviourSingleton<SpectrumManager>
{
    [SerializeField]
    private AudioSource audioSource = null;

    [SerializeField]
    private float[] samples = new float[512];

    [SerializeField]
    private FFTWindow FFTWindowType = FFTWindow.Blackman;

    public float[] Samples
    {
        get 
        {
            return this.samples;
        }
    }

    void Update() => audioSource.GetSpectrumData(samples, 0, FFTWindowType);
}
