using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordBank : MonoBehaviour {
	public string[] bank;
	public Text text;

	void Start() {
		var index = Random.Range (0, bank.Length - 1);
		text.text = "Please draw\n" + bank [index];
	}
}
