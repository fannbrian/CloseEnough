using UnityEngine;

public class PanelReference : MonoBehaviour {
	public GameObject WaitingPanel;
	public GameObject DrawingPanel;
	public GameObject GuessingPanel;
	public GameObject GalleryPanel;

	public static PanelReference singleton;

	// Use this for initialization
	void Start () {
		singleton = this;
	}   
}
