using UnityEngine;
using UnityEngine.UI;

public class ScreenCapture : MonoBehaviour
{
	bool grab;
	public RawImage image;
	Texture2D receivedTexture;

	Texture2D texture;
	byte [] pngEncoded;

	public RectTransform imagePanel;
	// Screenshot image for user's drawing 
	public RawImage img;
	bool shot = false;



	// Use this for initialization
	void Start () {
		imagePanel.GetComponent<RectTransform> ();
		imagePanel.gameObject.SetActive (false);

		img.enabled = false;

		texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
	}

	private void Update (){
	
	}
			
	// Screen capture 
	public void done() {
		if (!shot) {
			StartCoroutine ("Capture");
		}
	}

	IEnumerator Capture() {
		yield return new WaitForEndOfFrame ();

		texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, false);
		texture.Apply();

		img.texture = texture;
		pngEncoded = new byte[texture.width];
		pngEncoded = texture.EncodeToPNG();

		// NetworkServer.SendBytesToReady (null, pngEncoded, pngEncoded.Length, 0);

		shot = true;

	}

	public void showImage() {
		imagePanel.gameObject.SetActive (true);
		img.enabled = true;

	}
}
