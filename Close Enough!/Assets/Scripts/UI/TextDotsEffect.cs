using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Creates a '...' effect on the text this component is attached to.
/// </summary>
[RequireComponent(typeof(Text))]
public class TextDotsEffect : MonoBehaviour {
    public int totalDots;
    public float animationRate;

    int _currentDots;
    string _initialText;
    Text _textComponent;
    float elapsedTime;
    
	// Use this for initialization
	void Start () {
        _textComponent = GetComponent<Text>();
        _initialText = _textComponent.text;
        _currentDots = 0;
	}

	void Update () {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= 1f / animationRate)
        {
            elapsedTime = 0;
            _currentDots = ++_currentDots % (totalDots+1);

            var resultString = _initialText;

            for(int i = 0; i <= (_currentDots-1); i++)
            {
                resultString += '.';
            }

            _textComponent.text = resultString;
        }
	}
}
