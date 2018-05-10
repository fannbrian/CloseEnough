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
            PanelReference.singleton.DrawingPanel.SetActive(true);

			var currentIndex = (GameData.CurrentRound + GameData.InitialIndex) % GameData.PlayerCount;
			var nodes = GameData.DrawingStacks[currentIndex].Nodes;
			var node = nodes[nodes.Count - 1];

			Debug.Log("Your word is: " + node.Word);

			GamePlay.instance.wordToDraw = node.Word;         
			GamePlay.instance.Draw();
		}
		public override void OnExit()
		{
			PanelReference.singleton.DrawingPanel.SetActive(true);
		}
	}
}