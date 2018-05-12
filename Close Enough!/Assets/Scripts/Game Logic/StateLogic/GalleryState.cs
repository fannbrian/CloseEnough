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
			Timer.instance.ResetTimer(false);
			PanelReference.singleton.GalleryPanel.SetActive(true);
		}

        public override void OnExit()
        {
            PhotonNetwork.LeaveRoom(false);
            SceneManager.LoadScene("Menu Navigation");
        }
    }
}