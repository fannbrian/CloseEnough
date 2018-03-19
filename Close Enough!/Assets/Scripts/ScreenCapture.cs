﻿using System.Collections; using System.Collections.Generic; using UnityEngine;  namespace CloseEnough { public class ScreenCapture : MonoBehaviour {  	Texture2D screenCap; 	Texture2D border; 	bool shot = false;  	// Use this for initialization 	void Start () { 		screenCap = new Texture2D (Screen.width - 148, Screen.height - 96, TextureFormat.RGB24, false); 		border = new Texture2D (2, 2, TextureFormat.ARGB32, false); 		border.Apply (); 	}  	// Update is called once per frame 	void Update () { 		if (Input.GetKeyUp (KeyCode.Space)) { 			 		} 	}  	void OnGUI() { 		GUI.DrawTexture (new Rect (75, 50, Screen.width - 150, 2), border, ScaleMode.StretchToFill); //top 		GUI.DrawTexture (new Rect (75, Screen.height - 150, Screen.width - 150, 2), border, ScaleMode.StretchToFill); //bottom 		GUI.DrawTexture (new Rect (Screen.width - 75, 50, 2, Screen.height - 200), border, ScaleMode.StretchToFill); //right 		GUI.DrawTexture (new Rect (75, 50, 2, Screen.height - 200), border, ScaleMode.StretchToFill); //left  		if (shot) { 			GUI.DrawTexture (new Rect (10, 10, Screen.width/3, Screen.height/3), screenCap, ScaleMode.ScaleToFit); 		} 	}  	IEnumerator Capture() { 		yield return new WaitForEndOfFrame (); 		screenCap.ReadPixels(new Rect(73, 50, Screen.width - 150, Screen.height - 96),0, 0); 		screenCap.Apply (); 		shot = true; 	}  	public void Screenshot() { 		StartCoroutine ("Capture"); 	} 		 } }