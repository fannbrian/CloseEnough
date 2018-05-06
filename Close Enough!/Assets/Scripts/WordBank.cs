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
			if (GamePlay.rounds == GameInformation.rounds) {
				var index = Random.Range (0, bank.Length - 1);
				text.text += bank [index];
			} else {
					text.text += GamePlay.wordToDraw;
			}

		}
	}
}