//using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class ScreenCapture : MonoBehaviour {

	Texture2D texture;
	byte [] pngEncoded;

	// Screenshot image for user's drawing 
	public RawImage img;
	bool shot = false;


	// Use this for initialization
	void Start () {
		texture = new Texture2D(Screen.width - 230, Screen.height, TextureFormat.RGB24, false);
		img.enabled = false;
	}

	// Update is called once per frame
	void Update () {
	}
			
	IEnumerator Capture() {
		yield return new WaitForEndOfFrame ();

		texture.ReadPixels(new Rect(230, 0, Screen.width - 230, Screen.height), 0, 0, false);
		texture.Apply();

		img.texture = texture;
		pngEncoded = new byte[texture.width];
		pngEncoded = texture.EncodeToPNG();

		NetworkServer.SendBytesToReady (null, pngEncoded, pngEncoded.Length, 0);

		shot = true;

	}

	// Screen capture 
	public void done() {
		if (!shot) {
			StartCoroutine ("Capture");
			img.enabled = true;

		}
	}
}
