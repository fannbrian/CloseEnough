using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {
	// Initialize the audio mixer
	public AudioMixer audioMixer;

    public Slider MasterSlider;
    public Slider BgmSlider;
    public Slider SfxSlider;

    public bool isDirty;

    private float _masterVolume;
    private float _bgmVolume;
    private float _sfxVolume;

    private const string MASTER_KEY = "MasterVolume";
    private const string BGM_KEY = "BgmVolume";
    private const string SFX_KEY = "SfxVolume";

    
    float TryGetVolume(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            return PlayerPrefs.GetFloat(key);
        }

        Debug.Log("Could not find " + key);
        return 0;
    }

    void Start()
    {
        _masterVolume = TryGetVolume(MASTER_KEY);
        _bgmVolume = TryGetVolume(BGM_KEY);
        _sfxVolume = TryGetVolume(SFX_KEY);

        Debug.Log(_masterVolume + ", " + _bgmVolume + ", " + _sfxVolume);

        audioMixer.SetFloat(MASTER_KEY, _masterVolume);
        audioMixer.SetFloat(BGM_KEY, _bgmVolume);
        audioMixer.SetFloat(SFX_KEY, _sfxVolume);

        MasterSlider.value = _masterVolume;
        BgmSlider.value = _bgmVolume;
        SfxSlider.value = _sfxVolume;
    }

    // Set the volume of the audio slider
    public void SetMasterVolume(float volume)
    {
        _masterVolume = volume;
        audioMixer.SetFloat(MASTER_KEY, volume);
        isDirty = true;
    }
    // Set the volume of the audio slider
    public void SetBgmVolume(float volume)
    {
        _bgmVolume = volume;
        audioMixer.SetFloat(BGM_KEY, volume);
        isDirty = true;
    }
    // Set the volume of the audio slider
    public void SetSfxVolume(float volume)
    {
        _sfxVolume = volume;
        audioMixer.SetFloat(SFX_KEY, volume);
        isDirty = true;
    }

    public void Save()
    {
        if (isDirty)
        {
            isDirty = false;
            PlayerPrefs.SetFloat(MASTER_KEY, _masterVolume);
            PlayerPrefs.SetFloat(BGM_KEY, _bgmVolume);
            PlayerPrefs.SetFloat(SFX_KEY, _sfxVolume);
            PlayerPrefs.Save();
        }
    }
}
