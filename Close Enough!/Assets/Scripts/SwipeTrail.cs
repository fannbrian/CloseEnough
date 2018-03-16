using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles drawing mechanic
/// 
/// Created by Alexander Berthon and Jennifer Luong
/// 
/// Refactored by Brian Fann
/// </summary>
public class SwipeTrail : MonoBehaviour
{

    public GameObject trailPrefab;
    Stack<GameObject> _instantiatedSwipes;

    void Start()
    {
        _instantiatedSwipes = new Stack<GameObject>();
    }

    void StartSwipe(Vector3 position) {
        var pos = Camera.main.ScreenToWorldPoint(position);
        pos.z = 0;
        var trail = Instantiate(trailPrefab, pos, Quaternion.identity);
        _instantiatedSwipes.Push(trail);
    }

    void UpdateSwipe(Vector3 position) {
        var pos = Camera.main.ScreenToWorldPoint(position);
        pos.z = 0;
        var trail = _instantiatedSwipes.Peek();

        trail.transform.position = pos;
    }

    void Update()
    {
#if UNITY_ANDROID || UNITY_IOS
        if (Input.touchCount <= 0) return;

        var touch = Input.GetTouch(0);
        var targetPos = touch.position;

        if (touch.phase == TouchPhase.Began) {
            StartSwipe(targetPos);
        } else if (touch.phase == TouchPhase.Moved) {
            UpdateSwipe(targetPos);
		}
#elif UNITY_EDITOR
        var targetPos = Input.mousePosition;

        if (Input.GetMouseButtonDown(0)) {
            StartSwipe(targetPos);
        }
        else if (Input.GetMouseButton(0)) {
            UpdateSwipe(targetPos);
        }
        #endif
    }

	public void Undo(){
        Destroy(_instantiatedSwipes.Pop());
	}
}