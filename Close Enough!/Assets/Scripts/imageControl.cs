using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class imageControl : MonoBehaviour {

	RawImage image; 

	// Use this for initialization
	void Start () {
		image = GetComponent<RawImage>();
		image.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (image == null) {
			image = GetComponent<RawImage> ();
		}
		if (image.texture != null) {
			image.enabled = true;
		}
	}
}
