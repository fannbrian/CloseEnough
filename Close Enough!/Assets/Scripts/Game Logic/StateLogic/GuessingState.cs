using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CloseEnough
{
	public class GuessingState : BaseGameState
	{
		public override BaseGameState GetNextState()
		{
			if (GameData.CurrentRound < GameData.PlayerCount) {
				return new DrawingState();            
			}

			return new GalleryState();
		}

		public override void OnEnter()
		{
            var currentIndex = (GameData.CurrentRound + GameData.InitialIndex) % GameData.PlayerCount;
            var nodes = GameData.DrawingStacks[currentIndex].Nodes;
            var node = nodes[nodes.Count - 1];

			var drawing = new Texture2D(2, 2);
			drawing.LoadImage(node.Drawing);

			var size = GamePlay.instance.screenCap.GetTextureSize();
            
			TextureScale.Bilinear(drawing, (int)size.x, (int)size.y);

			GamePlay.instance.screenCap.SetImage(drawing);
			GamePlay.instance.Guess();
			PanelReference.singleton.GuessingPanel.SetActive(true);
		}

		public override void OnExit()
		{
			GameData.PlayersDone -= GameData.PlayerCount;
			GameData.CurrentRound++;
			PanelReference.singleton.WaitingPanel.SetActive(false);
			PanelReference.singleton.GuessingPanel.SetActive(false);
		}
	}
}