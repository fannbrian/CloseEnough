using UnityEngine;

namespace CloseEnough
{
    public class DrawingState : BaseGameState
    {
        public override BaseGameState GetNextState()
		{
            if (GameData.instance.CurrentRound < GameData.instance.PlayerCount)
            {
				return new GuessingState();
            }
            
            return new GalleryState();
        }

		public override void OnEnter()
		{
			GameData.instance.PlayersDone = 0;
            PanelReference.singleton.WaitingPanel.SetActive(false);
            PanelReference.singleton.DrawingPanel.SetActive(true);

			RoundManager.instance = new DrawingRoundManager();
			RoundManager.instance.StartRound();
		}

		public override void OnExit()
		{
            GameData.instance.PlayersDone = 0;

			PanelReference.singleton.WaitingPanel.SetActive(false);
			PanelReference.singleton.DrawingPanel.SetActive(false);
		}
	}
}