using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CloseEnough {
public class ScreenCapture : MonoBehaviour {

//	Texture2D screenCap;

	public Renderer rend;

	// Use this for initialization
	void Start () {
//		screenCap = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, true);

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.Space)) {
			StartCoroutine ("Capture");
			
		}
				
	}
			
	IEnumerator Capture() {
		yield return new WaitForEndOfFrame ();
		Texture2D texture = new Texture2D (Screen.width, Screen.height, TextureFormat.RGB24, true);
		texture.ReadPixels (new Rect (0, 0, Screen.width, Screen.height), 0, 0);
		texture.Apply ();

		rend.material.mainTexture = texture;



//		screenCap.ReadPixels(new Rect(0, 0, Screen.width, Screen.height),0, 0);
//		screenCap.Apply ();
	}
//
//	public void Screenshot() {
//		StartCoroutine ("Capture");
//	}
		
}
}