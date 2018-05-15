using UnityEngine;

public class PanelReference : MonoBehaviour {
	public GameObject WaitingPanel;
	public GameObject DrawingPanel;
	public GameObject GuessingPanel;
	public GameObject GalleryPanel;
	public GameObject WarningPanel;
	public GameObject InformationPanel;
	public GameObject Countdown;
	public GameObject Timer;

	public static PanelReference singleton;

	// Use this for initialization
	void Start () {
		singleton = this;
	}   
}
