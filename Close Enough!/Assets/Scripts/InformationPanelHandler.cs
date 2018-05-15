using UnityEngine;

namespace CloseEnough
{
	public class InformationPanelHandler : MonoBehaviour
	{
		public GameObject InformationPanel;

		public void TryOpen()
		{
			if (!RoundManager.instance.IsRunning) return;

			InformationPanel.SetActive(!InformationPanel.GetActive());
		}
	}
}