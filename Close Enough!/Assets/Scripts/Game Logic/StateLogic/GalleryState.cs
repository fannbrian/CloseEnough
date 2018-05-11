using UnityEngine;

namespace CloseEnough
{
	public class GalleryState : BaseGameState
	{
		public override BaseGameState GetNextState()
		{
			return new MenuState();
		}

		public override void OnEnter()
		{
			Timer.instance.ResetTimer(false);
			PanelReference.singleton.GalleryPanel.SetActive(true);
		}
	}
}