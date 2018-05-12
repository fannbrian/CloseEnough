using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace CloseEnough {
	public class ScreenCapture : MonoBehaviour
	{
	    public RectTransform rectTransform;
	    bool grab;
		Texture2D receivedTexture;

		public Texture2D texture;

		public RectTransform imagePanel;
		// Screenshot image for user's drawing 
		public RawImage image;

	    Camera _camera;
	    Rect _screenshotRect;
	    int _width;
	    int _height;

	    void Start()
	    {
	        imagePanel.GetComponent<RectTransform>();
	        imagePanel.gameObject.SetActive(false);

	        image.enabled = false;

            var rect = RectTransformToScreenSpace(rectTransform);
	        _width = (int)rect.width;
	        _height = (int)rect.height;
	        var pos = new Vector2((int)((Screen.width - _width) / 2), (int)((Screen.height-_height) / 2 ));
	        texture = new Texture2D(_width, _height-1, TextureFormat.RGB24, false);

	        _screenshotRect = new Rect(pos, new Vector2(_width, _height-1));
	    }

	    public Rect RectTransformToScreenSpace(RectTransform transform)
	    {
	        Vector2 size = Vector2.Scale(transform.rect.size, transform.lossyScale);
	        float x = transform.position.x + transform.anchoredPosition.x;
	        float y = Screen.height - transform.position.y - transform.anchoredPosition.y;

	        return new Rect(x, y, size.x, size.y);
	    }

		public Vector2 GetTextureSize() {
			return Vector2.Scale(rectTransform.rect.size, rectTransform.lossyScale);
		}
	    
		// Screen capture 
		public void Screenshot() {
			StartCoroutine ("Capture");
		}

		public void SetImage(Texture2D img) {
			image.texture = img;
		}

		IEnumerator Capture() {
			yield return new WaitForEndOfFrame ();

            texture.ReadPixels(_screenshotRect, 0, 0, false);
            texture.Apply();

			image.texture = texture;
		}

		public void showImage() {
			imagePanel.gameObject.SetActive (true);
			image.enabled = true;
		}
	}
}