using UnityEngine;

namespace CloseEnough
{
    public class DrawingState : BaseGameState
    {
        public override BaseGameState GetNextState()
		{
            if (GameData.CurrentRound < GameData.PlayerCount)
            {
				return new GuessingState();
            }
            
            return new GalleryState();
        }

		public override void OnEnter()
		{
			GameData.PlayersDone = 0;
            PanelReference.singleton.DrawingPanel.SetActive(true);

			var currentIndex = (GameData.CurrentRound + GameData.InitialIndex) % GameData.PlayerCount;
			var nodes = GameData.DrawingStacks[currentIndex].Nodes;
			var node = nodes[nodes.Count - 1];
         
			GamePlay.instance.wordToDraw = node.Word;         
			GamePlay.instance.Draw();
		}

		public override void OnExit()
		{
			GameData.PlayersDone -= GameData.PlayerCount;
			PanelReference.singleton.WaitingPanel.SetActive(false);
			PanelReference.singleton.DrawingPanel.SetActive(false);
		}
	}
}