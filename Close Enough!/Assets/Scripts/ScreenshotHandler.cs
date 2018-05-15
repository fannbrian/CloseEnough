using UnityEngine;

namespace CloseEnough
{
	public class ScreenshotHandler : MonoBehaviour
	{
		public static ScreenshotHandler instance;

		void Awake()
		{
			instance = this;
		}

		public void SendScreenshot()
		{
			Invoke("Screenshot", 0.5f);
			Invoke("SendData", 1f);
		}

		/// <summary>
		/// Screenshots the drawing
		/// </summary>
		void Screenshot()
		{
			DrawingPanelReferences.instance.Capture.Screenshot();
		}

		/// <summary>
		/// Sends drawing data
		/// </summary>
		void SendData()
		{
			var texBytes = DrawingPanelReferences.instance.Capture.texture.EncodeToJPG();

			// UI
			SwipeTrail.singleton.Clear();

			var node = new StackNode(PhotonNetwork.player.ID, texBytes);
			var nodeBytes = ByteSerializer<StackNode>.Serialize(node);

			PanelReference.singleton.WaitingPanel.SetActive(true);
			GameData.instance.LocalView.RPC("SendNode", PhotonTargets.All, GameData.instance.CurrentIndex, nodeBytes);
		}
	}
}