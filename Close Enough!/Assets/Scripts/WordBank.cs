using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CloseEnough {
	public class WordBank : MonoBehaviour {
		public string[] bank;
		public Text text;
		public GamePlay game;

		void Start() {
			
			var index = Random.Range (0, bank.Length - 1);
			text.text = "Please draw\n" + bank [index];
		}
	}
}