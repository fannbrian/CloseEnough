using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CloseEnough
{
	public class GuessingState : BaseGameState
	{
		public override BaseGameState GetNextState()
		{
			if (GameData.instance.CurrentRound < GameData.instance.PlayerCount) {
				return new DrawingState();            
			}

			return new GalleryState();
		}

		public override void OnEnter()
        {
            PanelReference.singleton.WaitingPanel.SetActive(false);
            PanelReference.singleton.GuessingPanel.SetActive(true);

			RoundManager.instance = new GuessingRoundManager();
			RoundManager.instance.StartRound();
		}

		public override void OnExit()
		{
			Debug.Log("EXIT CALLED");
			GameData.instance.PlayersDone = 0;

			PanelReference.singleton.WaitingPanel.SetActive(false);
			PanelReference.singleton.GuessingPanel.SetActive(false);
		}
	}
}