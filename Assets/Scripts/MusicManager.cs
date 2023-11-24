using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
    }
 
    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
    }
}