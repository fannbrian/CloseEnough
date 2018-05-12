using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        public static SwipeTrail singleton;
        public GameObject trailPrefab;
        public float maxAngleThreshold;

        List<Vector3> _positions;
        Vector3 _vertex;
        Stack<List<GameObject>> _instantiatedSwipes;
		LineRenderer _renderer;
        bool _isDrawing;

        void Awake()
        {
            singleton = this;
            _positions = new List<Vector3>();
            _instantiatedSwipes = new Stack<List<GameObject>>();
            _isDrawing = false;
        }

		GameObject CreateSwipe(Vector3[] positions) {
            _positions.Clear();

            foreach(var pos in positions) {
                _positions.Add(pos);
            }

            if (_positions.Count == 1) {
                _positions.Add(positions[0]);
            }

            var trail = Instantiate(trailPrefab, positions[0], Quaternion.identity);
            _renderer = trail.GetComponent<LineRenderer>();
            _renderer.sortingOrder = _instantiatedSwipes.Count;
            _renderer.SetPositions(_positions.ToArray());

            return trail;
        }

        public void NewSwipe(Vector3 pos) {
            _instantiatedSwipes.Peek().Add(CreateSwipe(new Vector3[] { _vertex, pos }));
        }

        public void StartSwipe(Vector3 position)
		{
            if (ToolsStateManager.singleton.CurrentState.Name == ToolsStateManager.singleton.DisableString) return;
            if (UIRaycastDetector.singleton.IsPositionOverUI(position)) return;

            var group = new List<GameObject>();
            _instantiatedSwipes.Push(group);
            _isDrawing = true;

            var pos = Camera.main.ScreenToWorldPoint(position);
            pos.z = 0;

            group.Add(CreateSwipe(new Vector3[] { pos }));
        }

        bool isAngleValid() {
            var count = _positions.Count;
            if (count >= 3)
            {
                // b is a vertex
                var a = _positions[count-3];
                var b = _positions[count-2];
                var c = _positions[count-1];
                var distAB = Vector3.Distance(a, b);
                var distBC = Vector3.Distance(b, c);
                var distAC = Vector3.Distance(a, c);

                // Law of Cosines: arccos((AB^2 + AC^2 - BC^2) / (2 * AB * AC))
                var dividend = distAB * distAB + distAC * distAC - distBC * distBC;
                var divisor = 2 * distAB * distAC;

                if (divisor != 0)
                {
                    var angle = Mathf.Acos(dividend / divisor) * Mathf.Rad2Deg;
                    if (angle > maxAngleThreshold)
                    {
                        _vertex = b;
                        return false;
                    }
                }
            }

            return true;
        }

        void UpdateSwipe(Vector3 position)
        {
            _isDrawing = false;
            
            if (ToolsStateManager.singleton.CurrentState.Name == ToolsStateManager.singleton.DisableString) return;
            if (_instantiatedSwipes.Count <= 0) return;

            _isDrawing = true;

            var pos = Camera.main.ScreenToWorldPoint(position);
            pos.z = 0;

            if (pos == _positions[_positions.Count - 1]) return;

            _positions.Add(pos);

            if (!isAngleValid()) {
                NewSwipe(pos);
            }

            _renderer.positionCount = _positions.Count;
            _renderer.SetPositions(_positions.ToArray());
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
#elif UNITY_EDITOR || UNITY_STANDALONE || UNITY_STANDALONE_OSX
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
                var group = _instantiatedSwipes.Pop();

                foreach(var swipe in group) {
                    Destroy(swipe);
                }
            }
        }

		public void Clear()
		{
			while (_instantiatedSwipes.Count > 0)
			{
				var group = _instantiatedSwipes.Pop();

				foreach(var swipe in group)
				{
					Destroy(swipe);
				}
			}
		}
    }
}