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
		public GameObject ScrollDots;
		public GameObject DrawingPanelPrefab;
		public GameObject GuessPanelPrefab;
		public GameObject BackButton;

		ScrollDots _scrollDots;

		float _snapPosition;
		float _currentInterpolation;
		float _currentPosition;
		int _pageCount;
		bool _isSnapping;      

		// Use this for initialization
		void Start()
		{         
            _currentInterpolation = MinInterpolation;
		}
        
        /// <summary>
        /// Creates a drawing panel and initializes the data.
        /// </summary>
		/// <para>
		/// @Author: Brian Fann
		/// @Last Updated: 5/10/18
		/// </para>
        /// <returns>The drawing panel.</returns>
        /// <param name="node">Node.</param>
		public GameObject InstantiateDrawing(StackNode node) {
			var obj = Instantiate(DrawingPanelPrefab, ScrollView.content);
			var drawingPanel = obj.GetComponent<DrawingStackReference>();

            // Load drawing into image
			var tex = new Texture2D(2, 2);

			tex.LoadImage(node.Drawing);
			drawingPanel.Drawing.texture = tex;

			// Set label
			drawingPanel.Owner.text = PhotonPlayer.Find(node.Owner).NickName + " drew:";

			return obj;
		}

        /// <summary>
        /// Creates a guess panel and initializes the data.
        /// </summary>
		/// <para>
		/// @Author: Brian Fann
		/// @Last Updated: 5/10/18
		/// </para>
        /// <returns>The guess.</returns>
        /// <param name="node">Node.</param>
		public GameObject InstantiateGuess(StackNode node) {         
			var obj = Instantiate(GuessPanelPrefab, ScrollView.content);
			var guessPanel = obj.GetComponent<GuessStackReference>();
         
            // Set word
			if (node.Word != "") {            
                guessPanel.Word.text = node.Word;
			}
			else {
				guessPanel.Word.text = "did not guess.";
			}

			// Set label
			guessPanel.Owner.text = PhotonPlayer.Find(node.Owner).NickName;

			if (node.Word != "")
			{
				guessPanel.Owner.text += " guessed:";
			}

            return obj;
		}

        /// <summary>
        /// Initializes the carousel view by 
        /// </summary>
        /// <param name="stack">Stack.</param>
		public void Initialize(DrawingStack stack) {
			_pageCount = stack.Nodes.Count;

			// Instantiate the initial stack node (specifically for the '<Owner> got:' label)
			if (_pageCount > 0) {
				var obj = Instantiate(GuessPanelPrefab, ScrollView.content.transform).GetComponent<GuessStackReference>();
				obj.Owner.text = "The starting word was: ";
				obj.Word.text = stack.Nodes[0].Word;
			}

            // Iterate through each stack node and create a panel
			for (int i = 1; i < _pageCount; i++) {
				var node = stack.Nodes[i];
                
				if (node.Type == DrawingStackConstants.TYPE_DRAWING) {
					InstantiateDrawing(node);
				}
				else if (node.Type == DrawingStackConstants.TYPE_WORD) {
					InstantiateGuess(node);
				}
			}

			_scrollDots = ScrollDots.GetComponent<ScrollDots>();
			_scrollDots.Initialize(_pageCount);
		}

		// Update is called once per frame
		void Update()
		{
            var pos = ScrollView.horizontalNormalizedPosition;

			pos = Mathf.Clamp01(pos);

            var pageCount = ScrollView.content.childCount - 1;

            if (pageCount <= 0) return;

            var page = (int)Mathf.Round(pos * pageCount);

			_scrollDots.SetPage(page);

			if (Input.GetMouseButton(0)) {
				_isSnapping = false;
			}
            // Start snapping to position
			else if (Input.GetMouseButtonUp(0))
			{            
				_snapPosition = (float)page/pageCount;
                _currentInterpolation = MinInterpolation;
				_isSnapping = true;
			}
            
			if (_isSnapping)
			{            
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