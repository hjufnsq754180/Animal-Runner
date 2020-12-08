using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MixerController : MonoBehaviour
{
    [SerializeField] private AudioMixer mainMixer;

    [SerializeField] private Slider SfxSlider;
    [SerializeField] private Slider MusicSlider;

    [SerializeField] private float sfxVolume = 0.0001f;
    [SerializeField] private float musicVolume = 0.0001f;

    private void Start()
    {
        sfxVolume = PlayerPrefs.GetFloat("sfxVolume", .5f);
        mainMixer.SetFloat("sfxVolume", sfxVolume);
        SfxSlider.value = sfxVolume;

        musicVolume = PlayerPrefs.GetFloat("soundVolume", .5f);
        mainMixer.SetFloat("soundVolume", musicVolume);
        MusicSlider.value = musicVolume;
    }

    public void ChangeSfxSlider()
    {
        sfxVolume = SfxSlider.value;
        mainMixer.SetFloat("sfxVolume",Mathf.Log10(sfxVolume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", sfxVolume);
    }
    
    public void ChangeMusicSlider()
    {
        musicVolume = MusicSlider.value;
        mainMixer.SetFloat("soundVolume", Mathf.Log10(musicVolume) * 20);
        PlayerPrefs.SetFloat("soundVolume", musicVolume);
    }
    
}
