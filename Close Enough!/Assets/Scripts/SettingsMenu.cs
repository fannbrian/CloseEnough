using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour {
	// Initialize the audio mixer
	public AudioMixer audioMixer;
    public bool isDirty;

    private float _bgmVolume;
    private float _sfxVolume;

    private const string BGM_KEY = "bgmVolume";
    private const string SFX_KEY = "sfxVolume";

    public void Awake()
    {
        audioMixer.SetFloat("Audio", _bgmVolume);
    }

    // Set the volume of the audio slider
    public void SetVolume(float volume)
	{
		audioMixer.SetFloat ("Audio", volume);
        isDirty = true;
	}
    
    public void Save()
    {
        if (isDirty)
        {
            isDirty = false;
            PlayerPrefs.SetFloat(BGM_KEY, _bgmVolume);
            PlayerPrefs.SetFloat(SFX_KEY, _sfxVolume);
            PlayerPrefs.Save();
        }
    }
}
