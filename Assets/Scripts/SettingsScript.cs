using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    [SerializeField] AudioMixer masterMixer;
    [SerializeField] Slider sensitivitySlider;
    [SerializeField] Slider MusicVolumeSlider;
    [SerializeField] Slider SFXVolumeSlider;
    [SerializeField] bool isMainMenu = false;
    CameraController cameraController;

    private void Start() {
        cameraController = FindObjectOfType<CameraController>();

        // If the player has any saved settings then load them otherwise set them to default
        if(!isMainMenu) {
            switch(PlayerPrefs.HasKey("PlayerSens")) {
                case true:
                    LoadSensitivity();
                    break;
                case false:
                    SetSensitivity();
                    break;
            }
        }
        switch(PlayerPrefs.HasKey("musicVolume")) {
            case true:
                LoadMusicVolume();
                break;
            case false:
                SetMusicVolume();
                break;
        }
        switch(PlayerPrefs.HasKey("sfxVolume")) {
            case true:
                LoadSFXVolume();
                break;
            case false:
                SetSFXVolume();
                break;
        }
    }

    
    void LoadSensitivity() {
        sensitivitySlider.value = PlayerPrefs.GetFloat("PlayerSens");
        SetSensitivity();
    }
    void LoadMusicVolume() {
        MusicVolumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SetMusicVolume();
    }
    void LoadSFXVolume() {
        SFXVolumeSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        SetSFXVolume();
    }
    public void SetSensitivity() {
        float value = sensitivitySlider.value;
        PlayerPrefs.SetFloat("PlayerSens", value);
        cameraController.sensitivity = sensitivitySlider.value;
    }
    public void SetMusicVolume() {
        float volume = MusicVolumeSlider.value;
        masterMixer.SetFloat("MixerMusicVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }
    public void SetSFXVolume() {
        float volume = SFXVolumeSlider.value;
        masterMixer.SetFloat("MixerSFXVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }
}
