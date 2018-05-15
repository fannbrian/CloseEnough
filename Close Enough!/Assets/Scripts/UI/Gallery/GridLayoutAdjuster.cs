using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class GridLayoutAdjuster : MonoBehaviour {
	public float MaxGap = 100;
	public float MinGap = 50;
	GridLayoutGroup _grid;

	void Awake () {
		Debug.Log("Awek");
		_grid = GetComponent<GridLayoutGroup>();
		var ratio = (float)Screen.height / Screen.width;

		var yGap = (MaxGap - MinGap) * ratio + MinGap;

		_grid.spacing = new Vector2(50, yGap);
	}
}
