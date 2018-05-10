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
			GameData.LocalView = PhotonNetwork.Instantiate("PhotonPlayer", Vector3.zero, Quaternion.identity, 0).GetComponent<PhotonView>();
			GameData.LocalView.RPC("GameLoaded", PhotonTargets.All);

			var currentState = GameStateManager.singleton.CurrentState;
			if (currentState.GetNextState().GetType() == typeof(InitialState)) {
				GameStateManager.singleton.TransitionNextState();
			}
		}
	}
}
