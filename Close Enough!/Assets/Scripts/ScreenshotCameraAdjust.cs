using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ScreenshotCameraAdjust : MonoBehaviour {
    public RectTransform rectTransform;
    Camera _camera;

	// Use this for initialization
	void Start () {
        var rect = RectTransformToScreenSpace(rectTransform);
        var width = rect.width;
        var wRatio = width / Screen.width;
        var height = rect.height;
        var hRatio = height / Screen.height;

        Debug.Log("Screen: " + Screen.width + ", " + Screen.height);
        Debug.Log("Rect: " + width + ", " + height);

        _camera = GetComponent<Camera>();

        _camera.rect = new Rect(Vector2.zero, new Vector2(wRatio, hRatio));
	}
    public Rect RectTransformToScreenSpace(RectTransform transform)
    {
        Vector2 size = Vector2.Scale(transform.rect.size, transform.lossyScale);
        float x = transform.position.x + transform.anchoredPosition.x;
        float y = Screen.height - transform.position.y - transform.anchoredPosition.y;

        return new Rect(x, y, size.x, size.y);
    }
}
