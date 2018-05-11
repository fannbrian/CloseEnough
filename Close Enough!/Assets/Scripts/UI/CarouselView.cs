using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CloseEnough
{
	public class CarouselView : MonoBehaviour
	{
		public float MinInterpolation;
		public float SnapTime;
		public ScrollRect ScrollView;

		float _snapPosition;
		float _currentInterpolation;
		float _currentPosition;
		bool _isSnapping;      

		// Use this for initialization
		void Start()
		{         
            _currentInterpolation = MinInterpolation;
		}

		// Update is called once per frame
		void Update()
		{
			if (Input.GetMouseButton(0)) {
				_isSnapping = false;
			}
			else if (Input.GetMouseButtonUp(0))
			{
                var position = ScrollView.horizontalNormalizedPosition;

				if (position < 0) {
					position = 0;
				}
               
				var pageCount = ScrollView.content.childCount - 1;

				if (pageCount <= 0) return;

				var page = (int)Mathf.Round(position * pageCount);
                
				if (page > pageCount) {
					page = pageCount;
				}

				_snapPosition = (page/pageCount);
				Debug.Log("Current Page" + page);
                //Debug.Log("snapping to: " + _snapPosition);
                _currentInterpolation = MinInterpolation;
				_isSnapping = true;
			}
            
			if (_isSnapping)
			{
				var pos = ScrollView.horizontalNormalizedPosition;

				ScrollView.horizontalNormalizedPosition = Mathf.Lerp(pos, _snapPosition, _currentInterpolation);

				if (_currentInterpolation < 1) {
					_currentInterpolation += (1 - MinInterpolation) / SnapTime * Time.deltaTime;
				}
				else {
					_isSnapping = false;
				}
			}
		}
	}
}