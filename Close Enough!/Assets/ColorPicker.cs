using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : MonoBehaviour {

	public Material[] color;
	public Renderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		rend.enabled = true;
	}

	// Update is called once per frame
	void Update () {
	}

	public void white() {
		rend.sharedMaterial = color [0];
	}
	public void red() {
		rend.sharedMaterial = color [1];
	}
	public void orange() {
		rend.sharedMaterial = color [2];
	}
	public void yellow() {
		rend.sharedMaterial = color [3];
	}
	public void green() {
		rend.sharedMaterial = color [4];
	}
	public void blue() {
		rend.sharedMaterial = color [5];
	}
	public void purple() {
		rend.sharedMaterial = color [6];
	}
	public void brown() {
		rend.sharedMaterial = color [7];
	}
	public void black() {
		rend.sharedMaterial = color [8];
	}


}
	