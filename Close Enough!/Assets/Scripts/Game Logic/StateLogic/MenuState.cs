using UnityEngine.SceneManagement;

namespace CloseEnough
{
	/// <summary>
	/// Determines which scene to load
	/// </summary>
    public class MenuState : BaseGameState
    {
		public override BaseGameState GetNextState()
		{
			return new InitialState();
		}

		public override void OnEnter()
		{
			PhotonNetwork.automaticallySyncScene = false;
			SceneManager.LoadScene("Menu Navigation");
		}


		public override void OnExit()
		{
            if (PhotonNetwork.isMasterClient) {
				PhotonNetwork.LoadLevel("Main");
            }
		}
	}
}