using UnityEngine;
using UnityEngine.UI;
namespace CloseEnough
{
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