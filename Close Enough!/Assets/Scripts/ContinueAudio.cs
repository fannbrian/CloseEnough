using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueAudio : MonoBehaviour {

	private static ContinueAudio _instance;

	/// <summary>
	///  Continue playing audio after switching scenes
	/// </summary>

	public static ContinueAudio instance {
		get {
			if(_instance == null) {
				_instance = GameObject.FindObjectOfType<ContinueAudio>();
				DontDestroyOnLoad(_instance.gameObject);
			}
			return _instance;
		}
	}

	void Awake() {
//		DontDestroyOnLoad(this);

		// Creates an audio singleton
		if(_instance == null) {
			_instance = this;
			DontDestroyOnLoad(this);
		}
		else {
			//Destroy any other instances of Singleton
			if(this != _instance)
				Destroy(this.gameObject);
		}
	}
}
