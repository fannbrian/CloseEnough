using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour {
	public Text text;
	public string Name;

	public void UpdateText() {
		Name = text.text;
	}
}

//might not need this one anymore
