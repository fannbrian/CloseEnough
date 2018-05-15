using UnityEngine;

namespace CloseEnough
{
	public class GalleryExitHandler : MonoBehaviour
	{
		public GameObject WarningPanel;

		public void OnAcceptClick() {
			Debug.Log("CALLED");
            GameStateManager.singleton.TransitionNextState();
		}

		public void CloseWarning() {
			WarningPanel.SetActive(false);
		}
	}
}