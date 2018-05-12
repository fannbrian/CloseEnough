using UnityEngine;

namespace CloseEnough
{
	public class WarningButtonHandler : MonoBehaviour
	{
		public GameObject DrawingPanel;

		void OnEnable()
		{
            if (!DrawingPanel.activeInHierarchy) return;

            ToolsStateManager.singleton.TransitionState(ToolsStateManager.singleton.DisableString);
		}

		void OnDisable()
		{         
            if (!DrawingPanel.activeInHierarchy) return;

			ToolsStateManager.singleton.TransitionState(ToolsStateManager.singleton.IdleString);
		}

		public void OnAccept()
		{
			Debug.Log("ACCEPTED");
			GamePlay.instance.FinishRound();
		}
	}
}