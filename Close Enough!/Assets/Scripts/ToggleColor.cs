using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.PostProcessing;
using UnityEngine;

public class ToggleColor : MonoBehaviour {

	// Initialization
	public Toggle g_toggle;
	public PostProcessingProfile profile;

	public float grey = 0;
	public float normal = 1;

	void Start()
	{
		//Fetch the Toggle GameObject
		g_toggle = GetComponent<Toggle>();

		//Add listener for when the state of the Toggle changes, to take action
		g_toggle.onValueChanged.AddListener(delegate {
			ToggleValueChanged(g_toggle);
		});
	}
	
	//Output the new state of the Toggle into Text
	void ToggleValueChanged(Toggle change)
	{
		ColorGradingModel.Settings colorGradingSettings = profile.colorGrading.settings;

		if (g_toggle.isOn) {
			colorGradingSettings.basic.saturation = grey;
		} else {
			colorGradingSettings.basic.saturation = normal;
		}

		profile.colorGrading.settings = colorGradingSettings;
	}
}
