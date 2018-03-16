using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class FadingTextAnimation : MonoBehaviour {
    public float FadeTime;
    public float MinFade;
    bool _isFading;
    Text _text;
    float _currentTime;

	void Start () {
        _text = GetComponent<Text>();
        _isFading = true;
        _currentTime = FadeTime;
	}
	
	void Update () {
        _currentTime += Time.deltaTime;
        var color = _text.color;
        var fadeFactor = _currentTime / FadeTime;

        if (_isFading) {
            color.a = 1f - (1f-MinFade) * fadeFactor;
        }
        else {
            color.a = MinFade + fadeFactor;
        }

        if (_currentTime > FadeTime)
        {
            _currentTime = 0;
            _isFading = !_isFading;
        }

        _text.color = color;
	}
}
