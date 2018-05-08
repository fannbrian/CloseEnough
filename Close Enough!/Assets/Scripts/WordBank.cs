using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CloseEnough {
	public class WordBank : MonoBehaviour {
		public string[] bank;
		public Text text;

		void Start() {
			// Initial round
			text.text = "Your word is\n";
			if (GameInformation.initialRound) {
				var index = Random.Range (0, bank.Length - 1);
				text.text += bank [index];
				GameInformation.initialRound = false;
			// Every round after, words should be changed
			} else {
				text.text += GamePlay.wordToDraw;
			}

		}
	}
}