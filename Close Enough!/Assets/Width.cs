using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Width : MonoBehaviour {

	public float width = 0.1f;
	private TrailRenderer swipe;

	// Use this for initialization
	void Start () {
		swipe = GetComponent<TrailRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		swipe.widthMultiplier = width;
	}

	public void changeWidth(float newWidth){
		width = newWidth;
	}
}
