using UnityEngine;

namespace CloseEnough
{
	public class GalleryExitHandler : MonoBehaviour
	{
		public GameObject WarningPanel;

		public void OnAcceptClick() {
			Debug.Log("CALLED");
			NetworkRejoinData.instance = new NetworkRejoinData(PhotonNetwork.player.NickName, PhotonNetwork.room.Name);
            GameStateManager.singleton.TransitionNextState();
		}

		public void CloseWarning() {
			WarningPanel.SetActive(false);
		}
	}
}