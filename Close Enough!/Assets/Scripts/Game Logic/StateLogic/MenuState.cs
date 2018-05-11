using UnityEngine.SceneManagement;

namespace CloseEnough
{
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