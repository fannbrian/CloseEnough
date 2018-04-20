using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerSlide : MonoBehaviour {

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
			anim.Play ("Timer Slide");
			play = false;
		}
	}
}
