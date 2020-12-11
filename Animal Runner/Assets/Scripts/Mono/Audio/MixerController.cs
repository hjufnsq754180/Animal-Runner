using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MixerController : MonoBehaviour
{
    [SerializeField] private AudioMixer mainMixer;

    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider musicSlider;

    [SerializeField] private bool sfxToggle;
    [SerializeField] private bool musicToggle;

    [SerializeField] private GameObject sfxImageOn;
    [SerializeField] private GameObject sfxImageOff;

    [SerializeField] private GameObject musicImageOn;
    [SerializeField] private GameObject musicImageOff;

    [SerializeField] private float sfxVolume = 0.0001f;
    [SerializeField] private float musicVolume = 0.0001f;

    private void Start()
    {
        musicToggle = true;
        sfxToggle = true;

        sfxVolume = PlayerPrefs.GetFloat("sfxVolume", .5f);
        mainMixer.SetFloat("sfxVolume", sfxVolume);
        sfxSlider.value = sfxVolume;

        musicVolume = PlayerPrefs.GetFloat("soundVolume", .5f);
        mainMixer.SetFloat("soundVolume", musicVolume);
        musicSlider.value = musicVolume;

        LoadBoolData();
        SetMusicValue();
        SetSfxValue();
    }

    public void ChangeSfxSlider()
    {
        sfxVolume = sfxSlider.value;
        mainMixer.SetFloat("sfxVolume",Mathf.Log10(sfxVolume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", sfxVolume);
    }
    
    public void ChangeMusicSlider()
    {
        musicVolume = musicSlider.value;
        mainMixer.SetFloat("soundVolume", Mathf.Log10(musicVolume) * 20);
        PlayerPrefs.SetFloat("soundVolume", musicVolume);
    }

    public void SfxToggle()
    {
        if (!sfxToggle) // On
        {
            mainMixer.SetFloat("sfxVolume", Mathf.Log10(sfxVolume) * 20);
            sfxSlider.interactable = true;
            sfxImageOn.SetActive(true);
            sfxImageOff.SetActive(false);
            sfxToggle = true;
            SaveBoolData();
        }
        else if (sfxToggle) //Off
        {
            mainMixer.SetFloat("sfxVolume", -80);
            sfxSlider.interactable = false;
            sfxImageOn.SetActive(false);
            sfxImageOff.SetActive(true);
            sfxToggle = false;
            SaveBoolData();
        }
    }

    public void MusicToggle()
    {
        if (!musicToggle) // On
        {
            mainMixer.SetFloat("soundVolume", Mathf.Log10(musicVolume) * 20);
            musicSlider.interactable = true;

            musicImageOn.SetActive(true);
            musicImageOff.SetActive(false);
            musicToggle = true;
            SaveBoolData();
        }
        else if (musicToggle) // Off
        {
            mainMixer.SetFloat("soundVolume", -80);
            musicSlider.interactable = false;

            musicImageOn.SetActive(false);
            musicImageOff.SetActive(true);
            musicToggle = false;
            SaveBoolData();
        }
    }

    private void SetMusicValue()
    {
        if (musicToggle)
        {
            mainMixer.SetFloat("soundVolume", Mathf.Log10(musicVolume) * 20);
            musicSlider.interactable = true;
            musicImageOn.SetActive(true);
            musicImageOff.SetActive(false);
            musicToggle = true;
            SaveBoolData();
        }
        else if (!musicToggle)
        {
            mainMixer.SetFloat("soundVolume", -80);
            musicSlider.interactable = false;
            musicImageOn.SetActive(false);
            musicImageOff.SetActive(true);
            musicToggle = false;
            SaveBoolData();
        }
    }
    
    private void SetSfxValue()
    {
        if (sfxToggle)
        {
            mainMixer.SetFloat("sfxVolume", Mathf.Log10(sfxVolume) * 20);
            sfxSlider.interactable = true;
            sfxImageOn.SetActive(true);
            sfxImageOff.SetActive(false);
            sfxToggle = true;
            SaveBoolData();
        }
        else if (!sfxToggle)
        {
            mainMixer.SetFloat("sfxVolume", -80);
            sfxSlider.interactable = false;
            sfxImageOn.SetActive(false);
            sfxImageOff.SetActive(true);
            sfxToggle = false;
            SaveBoolData();
        }
    }

    int boolToInt(bool val)
    {
        if (val)
            return 1;
        else
            return 0;
    }

    bool intToBool(int val)
    {
        if (val != 0)
            return true;
        else
            return false;
    }

    private void SaveBoolData()
    {
        PlayerPrefs.SetInt("MusicToggle", boolToInt(musicToggle));
        PlayerPrefs.SetInt("SfxToggle", boolToInt(sfxToggle));
    }

    private void LoadBoolData()
    {
        musicToggle = intToBool(PlayerPrefs.GetInt("MusicToggle", 1));
        sfxToggle = intToBool(PlayerPrefs.GetInt("SfxToggle", 1));
    }

}
