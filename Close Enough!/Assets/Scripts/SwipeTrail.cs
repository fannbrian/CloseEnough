using System.Collections.Generic;
using UnityEngine;

namespace CloseEnough
{
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
        bool _isDrawing;

        void Start()
        {
            _instantiatedSwipes = new Stack<GameObject>();
            _isDrawing = false;
        }

        void StartSwipe(Vector3 position)
        {
            if (!ToolsStateManager.singleton.IsIdle()) return;
            if (UIRaycastDetector.singleton.IsPositionOverUI(position)) return;

            _isDrawing = true;

            var pos = Camera.main.ScreenToWorldPoint(position);
            pos.z = 0;

            var trail = Instantiate(trailPrefab, pos, Quaternion.identity);
            var trailRenderer = trail.GetComponent<TrailRenderer>();

            var color = ColorManager.singleton.CurrentColor;
            var size = SizeManager.singleton.GetStrokeSize();

            _instantiatedSwipes.Push(trail);
        }

        void UpdateSwipe(Vector3 position)
        {
            _isDrawing = false;

            if (!ToolsStateManager.singleton.IsIdle()) return;
            if (UIRaycastDetector.singleton.IsPositionOverUI(position)) return;
            if (_instantiatedSwipes.Count <= 0) return;

            _isDrawing = true;

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

            if (touch.phase == TouchPhase.Moved && _isDrawing)
            {
                UpdateSwipe(targetPos);
            }
            else if (!_isDrawing)
            {
                StartSwipe(targetPos);
            }

            if (touch.phase == TouchPhase.Ended)
            {
                _isDrawing = false;
            }
#elif UNITY_EDITOR
        var targetPos = Input.mousePosition;


        if (Input.GetMouseButtonUp(0))
        {
            _isDrawing = false;
        }

        if (!Input.GetMouseButton(0)) return;

        if (!_isDrawing) {
            StartSwipe(targetPos);
        }
        else {
            UpdateSwipe(targetPos);
        } 
#endif
        }

        public void Undo()
        {
            if (_instantiatedSwipes.Count > 0)
            {
                Destroy(_instantiatedSwipes.Pop());
            }
        }
    }
}