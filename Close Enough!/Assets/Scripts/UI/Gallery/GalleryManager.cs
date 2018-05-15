using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CloseEnough
{
	public class GalleryManager : MonoBehaviour
	{
		public static GalleryManager singleton;
		public ScrollRect ScrollView;
		public GameObject ButtonPrefab;
		public GameObject CarouselPrefab;

		GameObject[] _buttons;
		GameObject[] _carousels;
      
		// Use this for initialization
		void Awake()
		{
			singleton = this;
		}

		void OnEnable()
		{
			Instantiate();
		}

		/// <summary>
		/// Instantiates the buttons and carousel views
		/// <para>
		/// @Author: Brian Fann
		/// @Last Updated: 5/10/18
		/// </para>
		/// </summary>
		public void Instantiate()
		{
			// TODO - Create text buttons, create carousel views, attach buttons to carousel views.

			var stackCount = GameData.instance.DrawingStacks.Length;

			// Create text buttons
			_buttons = new GameObject[stackCount];
			_carousels = new GameObject[stackCount];

			// Create buttons and carousels.
			for (int i = 0; i < stackCount; i++)
			{
				var word = GameData.instance.DrawingStacks[i].Nodes[0].Word;
            
                // Initialze carousels
				_carousels[i] = Instantiate(CarouselPrefab, transform);
				var carouselView = _carousels[i].GetComponent<CarouselView>();
				carouselView.Initialize(GameData.instance.DrawingStacks[i]);
				carouselView.BackButton.GetComponent<Button>().onClick.AddListener(OnBack);
				_carousels[i].SetActive(false);

                // Initialize buttons
                _buttons[i] = Instantiate(ButtonPrefab, ScrollView.content);

				var btn = _buttons[i].GetComponent<Button>();
                btn.GetComponent<Text>().text = word.Replace(" ", "");
				btn.onClick.AddListener(() => GalleryPanelReferences.instance.WarningPanel.SetActive(false));

                var wrdBtn = _buttons[i].GetComponent<WordButton>();
				wrdBtn.Carousel = _carousels[i];
				wrdBtn.ScrollView = ScrollView;
			}
		}

        /// <summary>
        /// Returns back to the gallery main page
		/// <para>
		/// @Author: Brian Fann
		/// @Last Updated: 5/10/18
		/// </para>
        /// </summary>
		public void OnBack() {
			foreach(var carousel in _carousels) {
				carousel.SetActive(false);
			}

			ScrollView.gameObject.SetActive(true);
		}
	}
}