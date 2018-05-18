using UnityEngine;
namespace CloseEnough
{
	/// <summary>
	/// Creates initial round of the game
	/// </summary>
    public class InitialState : BaseGameState
    {
        public override BaseGameState GetNextState()
        {
            return new DrawingState();
        }

		public override void OnEnter()
        {
            // Create an InitialGameHandler.
            // Note: Just calling the constructor will automatically store this as a singleton.
            new InitialGameHandler();

            Debug.Log(" Initial State ");

            PhotonNetwork.automaticallySyncScene = false;

            GameData.instance.LocalView = PhotonNetwork.Instantiate("PhotonPlayer", Vector3.zero, Quaternion.identity, 0).GetComponent<PhotonView>();
            GameData.instance.LocalView.RPC("GameLoaded", PhotonTargets.All);

            var currentState = GameStateManager.singleton.CurrentState;
		}

		public override void OnExit()
		{
			// Remove the reference to the initial state handler.
			InitialGameHandler.singleton = null;
			PanelReference.singleton.WaitingPanel.SetActive(false);
		}
	}
}