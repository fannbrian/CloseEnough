using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Initializes scroll dots for a given stack
/// </summary>
public class ScrollDots : MonoBehaviour {
	public Color UnselectedColor;
	public Color SelectedColor;
	public GameObject DotPrefab;

	GameObject[] _dots;
	Image[] _dotColor;
	int _currentPage;

	public void Initialize(int pageCount) {
		_dots = new GameObject[pageCount];
		_dotColor = new Image[pageCount];
        
		for (int i = 0; i < pageCount; i++) {
			_dots[i] = Instantiate(DotPrefab, transform);
			_dotColor[i] = _dots[i].GetComponent<Image>();
		}

		_dotColor[0].color = SelectedColor;
	}

	public void SetPage(int page) {
		_dotColor[_currentPage].color = UnselectedColor;
		_currentPage = page;
		_dotColor[_currentPage].color = SelectedColor;
	}
}
