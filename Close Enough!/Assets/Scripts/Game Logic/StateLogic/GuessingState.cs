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
			PanelReference.singleton.GuessingPanel.SetActive(true);
		}

		public override void OnExit()
		{
			PanelReference.singleton.GuessingPanel.SetActive(false);
		}
	}
}