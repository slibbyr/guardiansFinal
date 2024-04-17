using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;

    private float MusicVolume = 1.0f;

    private void Start()
    {
        MusicVolume = PlayerPrefs.GetFloat("volume");
    }

    private void Update()
    {
        PlayerPrefs.SetFloat("volume", MusicVolume);
    }

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
        
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
