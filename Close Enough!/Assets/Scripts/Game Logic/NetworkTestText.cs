using UnityEngine;
using UnityEngine.UI;

namespace CloseEnough
{
	[RequireComponent(typeof(Text))]
	public class NetworkTestText : MonoBehaviour
	{
		public Text text;
		// Use this for initialization
		void Start()
		{
			text = GetComponent<Text>();
		}

		// Update is called once per frame
		void Update()
		{
			text.text = GameData.PlayerNames;
		}
	}
}