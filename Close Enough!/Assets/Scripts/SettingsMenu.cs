using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour {
	// Initialize the audio mixer
	public AudioMixer audioMixer;

	// Set the volume of the audio slider
	public void SetVolume(float volume)
	{
		audioMixer.SetFloat ("Audio", volume);
	}
}
