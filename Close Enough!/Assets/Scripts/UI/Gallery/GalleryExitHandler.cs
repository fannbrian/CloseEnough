using UnityEngine;

namespace CloseEnough
{
	public class GalleryExitHandler : MonoBehaviour
	{
		public GameObject WarningPanel;

		/// <summary>
		/// Raises the accept click event.
		/// After the gallery page, scene transitions to the next state
		/// </summary>
		public void OnAcceptClick() {
			Debug.Log("CALLED");
			NetworkRejoinData.instance.isReconnecting = true;
            GameStateManager.singleton.TransitionNextState();
		}

		public void CloseWarning() {
			WarningPanel.SetActive(false);
		}
	}
}