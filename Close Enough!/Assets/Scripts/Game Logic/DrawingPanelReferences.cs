using UnityEngine;
using UnityEngine.UI;

namespace CloseEnough
{
	public class DrawingPanelReferences : MonoBehaviour
	{
		public static DrawingPanelReferences instance;

		public GameObject DrawingPanel;
		public GameObject ToolsPanel;
		public GameObject SizePanel;
		public GameObject ColorPanel;
		public GameObject DonePanel;
		public GameObject SwipeManager;
		public GameObject InformationPanel;
		public Text InformationWordText;
		public Text InformationDescription;
        public Text RoundText;
        public Text WordDisplay;
		public ScreenCapture Capture;

		// Use this for initialization
		void Awake()
		{
			instance = this;
		}
	}
}