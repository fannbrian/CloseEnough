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
            PanelReference.singleton.DrawingPanel.SetActive(true);

			var currentIndex = (GameData.instance.CurrentRound + GameData.instance.InitialIndex) % GameData.instance.PlayerCount;
			var nodes = GameData.instance.DrawingStacks[currentIndex].Nodes;
			var node = nodes[nodes.Count - 1];
         
			GamePlay.instance.wordToDraw = node.Word;         
			GamePlay.instance.Draw();
		}

		public override void OnExit()
		{
            GameData.instance.PlayersDone = 0;
			PanelReference.singleton.WaitingPanel.SetActive(false);
			PanelReference.singleton.DrawingPanel.SetActive(false);
		}
	}
}