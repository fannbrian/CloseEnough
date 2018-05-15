using UnityEngine.SceneManagement;

namespace CloseEnough
{
	public class GalleryState : BaseGameState
	{
		public override BaseGameState GetNextState()
		{
            return null;
		}

		public override void OnEnter()
		{
			PanelReference.singleton.GalleryPanel.SetActive(true);
		}

        public override void OnExit()
		{
			PhotonNetwork.Disconnect();
            SceneManager.LoadScene("Menu Navigation");
        }
    }
}