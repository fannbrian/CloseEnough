using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Collect player's name to store
/// </summary>
public class PlayerData : MonoBehaviour {
	public Text text;
	public string Name;

	public void UpdateText() {
		Name = text.text;
	}
}
