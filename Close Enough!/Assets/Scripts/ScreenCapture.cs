using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CloseEnough {
	public class ScreenCapture : MonoBehaviour {

		public Image img;
		Texture2D texture;
		bool shot = false;

		// Use this for initialization
		void Start () {
			texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

		}

		// Update is called once per frame
		void Update () {
			if (Input.GetKeyUp (KeyCode.Space)) {
				StartCoroutine ("Capture");

				
			}
					
		}

		void OnGUI() {
			if (shot) {
				GUI.DrawTexture (new Rect (10, 10, 600, 450), texture, ScaleMode.StretchToFill);

			}
		}
				
		IEnumerator Capture() {
			yield return new WaitForEndOfFrame ();

			texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, false);
			texture.Apply();
			shot = true;

		}
		
	}
}