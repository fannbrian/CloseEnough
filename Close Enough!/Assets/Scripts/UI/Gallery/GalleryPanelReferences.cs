using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryPanelReferences : MonoBehaviour {
	public static GalleryPanelReferences instance;

	void Awake()
	{
		instance = this;
	}

	public GameObject WarningPanel;
}
