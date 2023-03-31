using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeController : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] string volumeParameter;
    [SerializeField] Slider volumeSlider;
    [SerializeField] Toggle muteToggle;
    [SerializeField] bool muted;

    void Awake()
    {
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
        muteToggle.onValueChanged.AddListener(Mute);
    }

    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat(volumeParameter, volumeSlider.maxValue);
        string muteValue = PlayerPrefs.GetString(volumeParameter + "mute", "false");
        if(muteValue == "False")
        {
            muted = false;
        }
        else if(muteValue == "True")
        {
            muted = true;
        }
        muteToggle.isOn = !muted;
    }

    void OnDissable()
    {
        PlayerPrefs.SetFloat(volumeParameter, volumeSlider.value);
        PlayerPrefs.SetString(volumeParameter + "Mute", muted.ToString());
    }

    public void ChangeVolume(float value)
    {
        mixer.SetFloat(volumeParameter, value);
        muteToggle.isOn = volumeSlider.value > volumeSlider.minVlaue;
    }

    void Mute(bool doundEnabled)
    {
        if(SoundEnabled)
        {
            float lastVolume = PlayerPrefs.GetFloat(volumeParameter, volumeSlider.maxValue);
            mixer.SetFloat(volumeParameter. lastVolume);
            muted = false;
        }
        else
        {
            PlayerPrefs.SetFloat(volumeParameter, volumeSlider-value);
            mixer.SetFloat(volumeParameter, volumeSlider.minValue);
            muted = true;
        }
    }
}
