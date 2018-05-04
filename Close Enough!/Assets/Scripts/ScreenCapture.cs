﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScreenCapture : MonoBehaviour
{
	bool grab;
	Texture2D receivedTexture;

	public Texture2D texture;

	public RectTransform imagePanel;
	// Screenshot image for user's drawing 
	public RawImage img;
	bool shot = false;



	// Use this for initialization
	void Start () {
		imagePanel.GetComponent<RectTransform> ();
		imagePanel.gameObject.SetActive (false);

		img.enabled = false;

		texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
	}

	private void Update (){
	
	}
			
	// Screen capture 
	public void done() {
		if (!shot) {
			StartCoroutine ("Capture");
		}
	}

	IEnumerator Capture() {
		yield return new WaitForEndOfFrame ();

		texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, false);
		texture.Apply();

		img.texture = texture;

		shot = true;

	}

	public void showImage() {
		imagePanel.gameObject.SetActive (true);
		img.enabled = true;

	}
}
