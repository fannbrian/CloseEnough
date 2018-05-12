using UnityEngine;

namespace CloseEnough
{
	/// <summary>
    /// Instantiates a PhotonView object over the network when a player first loads in.
    /// </summary>
	public class ViewLoader : MonoBehaviour
	{
		void Start()
		{
			GameData.instance.LocalView = PhotonNetwork.Instantiate("PhotonPlayer", Vector3.zero, Quaternion.identity, 0).GetComponent<PhotonView>();
			GameData.instance.LocalView.RPC("GameLoaded", PhotonTargets.All);

			var currentState = GameStateManager.singleton.CurrentState;
		}
	}
}
