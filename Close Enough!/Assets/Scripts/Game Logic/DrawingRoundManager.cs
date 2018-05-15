using UnityEngine;
using System.Threading;
namespace CloseEnough
{
	public class DrawingRoundManager : RoundManager
	{
		/// <summary>
        /// Start round, display word.
        /// </summary>
		public override void StartRound() {
			instance = this;
			Type = RoundType.Drawing;
			TimerLength = 30;

            var nodes = GameData.instance.CurrentStack.Nodes;
            var node = nodes[nodes.Count - 1];

			PanelReference.singleton.DrawingPanel.SetActive(true);

			DrawingPanelReferences.instance.DonePanel.GetComponent<DoneSlide>().PlayAnimation(true);
			DrawingPanelReferences.instance.ToolsPanel.GetComponent<ToolsSlide>().PlayAnimation(true);

			DrawingPanelReferences.instance.RoundText.text = "Drawing Round";

			var word = node.Word;
			var wordDisplay = DrawingPanelReferences.instance.WordDisplay;

            if (word == "")
            {
				wordDisplay.text = "...they didn't guess.\nFeel free to draw anything.";
				DrawingPanelReferences.instance.InformationDescription.text = "...they didn't guess";
				DrawingPanelReferences.instance.InformationWordText.text = "Feel free to draw anything";
            }
            else
            {
				wordDisplay.text = "Your word is: \n" + word;
				DrawingPanelReferences.instance.InformationDescription.text = "Your word is:";
                DrawingPanelReferences.instance.InformationWordText.text = word;
            }

			wordDisplay.gameObject.SetActive(true);
            DrawingPanelReferences.instance.RoundText.gameObject.SetActive(true);

			base.StartRound();
		}

        /// <summary>
        /// Hides UI and takes a screenshot.
        /// </summary>
		public override void EndRound() {
			if (!IsRunning) return;
         
			if (Timer.instance.gameObject.GetActive()) {
				Timer.instance.StopTimer();
			}
         
            base.EndRound();

			PanelReference.singleton.InformationPanel.SetActive(false);

			ToolsStateManager.singleton.Enable(false);
            DrawingPanelReferences.instance.DonePanel.GetComponent<DoneSlide>().PlayAnimation(false);
			DrawingPanelReferences.instance.ToolsPanel.GetComponent<ToolsSlide>().PlayAnimation(false);

			// Wait for UI to move out of the way, then screenshot
			ScreenshotHandler.instance.SendScreenshot();
		}

        /// <summary>
        /// Hide word text, enable drawing
        /// </summary>
		public override void OnCountdownFinish()
		{
            DrawingPanelReferences.instance.WordDisplay.gameObject.SetActive(false);
			DrawingPanelReferences.instance.RoundText.gameObject.SetActive(false);
            
			ToolsStateManager.singleton.Enable(true);

			base.OnCountdownFinish();
		}

	}
}