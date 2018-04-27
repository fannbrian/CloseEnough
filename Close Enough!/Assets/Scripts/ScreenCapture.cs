using UnityEngine;
using UnityEngine.UI;

public class ScreenCapture : MonoBehaviour
{
	bool grab;
	public RawImage image;
	Texture2D receivedTexture;

	public void start(){
		grab = false;
	}

	private void Update (){
	
	}

	public void callCapture(){
		grab = true;
	}


	private void OnPostRender(){
		if (grab) {
			Texture2D texture = new Texture2D (Screen.width, Screen.height, TextureFormat.RGB24, false);
			texture.ReadPixels (new Rect (0, 0, Screen.width, Screen.height), 0, 0, false);
			texture.Apply ();
			image.texture = texture;
		}
	}
}
