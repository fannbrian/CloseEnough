using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Animation slide.
/// </summary>
public class animationSlide : MonoBehaviour {

	Animator anim;

	public bool play;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		play = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (play) {
			anim.Play ("Test");
			play = false;
		}
	}

}