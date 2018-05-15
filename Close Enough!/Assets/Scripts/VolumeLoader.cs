using UnityEngine;
using UnityEngine.Audio;

namespace CloseEnough
{
	public class VolumeLoader : MonoBehaviour
	{
		public AudioMixer audioMixer;

		float TryGetVolume(string key)
		{
			if (PlayerPrefs.HasKey(key))
			{
				return PlayerPrefs.GetFloat(key);
			}

			Debug.Log("Could not find " + key);
			return 0;
		}

		// Use this for initialization
		void Start()
		{
			var masterVolume = TryGetVolume(SettingsMenu.MASTER_KEY);
			var bgmVolume = TryGetVolume(SettingsMenu.BGM_KEY);
			var sfxVolume = TryGetVolume(SettingsMenu.SFX_KEY);

			audioMixer.SetFloat(SettingsMenu.MASTER_KEY, masterVolume);
			audioMixer.SetFloat(SettingsMenu.BGM_KEY, bgmVolume);
			audioMixer.SetFloat(SettingsMenu.SFX_KEY, sfxVolume);

		}
	}
}