using UnityEngine;
using System.Collections.Generic;

namespace CloseEnough
{
    public class TrailHandler : MonoBehaviour
    {
        public float maxAngleThreshold;
        List<Vector3> _positions;
        bool _isDrawing;
        int _counter;

        void StartSwipe(Vector3 targetPos)
        {
            var pos = Camera.main.ScreenToWorldPoint(targetPos);
            pos.z = 0;

            _isDrawing = true;
            _positions = new List<Vector3>();
            _positions.Add(pos);
        }

        void UpdateSwipe(Vector3 targetPos)
        {
            var pos = Camera.main.ScreenToWorldPoint(targetPos);
            pos.z = 0;

            // If targetPos matches last position, return.
            if (_positions.Count < 3) {
                _positions.Add(pos);
                return;
            }

            if (pos == _positions[_positions.Count - 1]) return;

            _positions.Add(pos);
            if (_positions.Count >= 3)
            {
                // b is a vertex
                var a = _positions[0];
                var b = _positions[1];
                var c = _positions[2];
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
                        SwipeTrail.singleton.NewSwipe(pos);
                        _positions.Clear();
                    }
                    //Debug.Log(angle);
                }
            }
            while (_positions.Count > 3)
            {
                _positions.RemoveAt(0);
            }
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

            if (!_isDrawing)
            {
                StartSwipe(targetPos);
            }
            else
            {
                UpdateSwipe(targetPos);
            }
#endif
        }
    }
}