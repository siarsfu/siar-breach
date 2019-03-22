using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVisualizer : MonoBehaviour
{
    public Transform[] audioSpectrumObjects;
    public float heightMultiplier;
    public int numberOfSamples = 1024;
    public FFTWindow fftWindow;
    public float lerpTime = 1;

    Material _material;


    // Start is called before the first frame update
    void Start()
    {
        _material = GetComponent<MeshRenderer>().materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        float[] spectrum = new float[numberOfSamples];

        GetComponent<AudioSource>().GetSpectrumData(spectrum, 0, fftWindow);
        
        for(int i = 0; i < audioSpectrumObjects.Length; i++)
        {
            float intensity = spectrum[i] * heightMultiplier;

            float lerpY = Mathf.Lerp(audioSpectrumObjects[i].localScale.y, intensity, lerpTime);
            Vector3 newScale = new Vector3(audioSpectrumObjects[i].localScale.x, lerpY, audioSpectrumObjects[i].localScale.z);

            Color _color = new Color(audioSpectrumObjects[i].localScale.x, audioSpectrumObjects[i].localScale.y, audioSpectrumObjects[i].localScale.z);
            _material.SetColor("_EmissionColor", _color);



            audioSpectrumObjects[i].localScale = newScale;

        }
    }
}
