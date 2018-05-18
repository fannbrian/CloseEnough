using UnityEngine;
using UnityEngine.UI;
namespace CloseEnough
{
	/// <summary>
	/// Button for each word at its initial round
	/// </summary>
	public class WordButton : MonoBehaviour
	{
		public GameObject Carousel;
		public ScrollRect ScrollView;

		public void OnClick()
		{
			Carousel.SetActive(true);
			ScrollView.gameObject.SetActive(false);
		}
	}
}