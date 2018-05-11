using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnReload : MonoBehaviour {
	public static DestroyOnReload instance;

	void Start () {
		if (instance != null) {
			Destroy(instance.gameObject);
		}
		instance = this;
	}
}
