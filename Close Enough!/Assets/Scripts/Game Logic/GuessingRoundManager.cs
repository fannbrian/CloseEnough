using UnityEngine;

namespace CloseEnough
{
    public class GuessingRoundManager : RoundManager
    {
        /// <summary>
        /// Start round, display word.
        /// </summary>
        public override void StartRound()
        {
            instance = this;
            Type = RoundType.Guessing;
            TimerLength = 20;

            var nodes = GameData.instance.CurrentStack.Nodes;
            var node = nodes[nodes.Count - 1];

			PanelReference.singleton.GuessingPanel.SetActive(true);
         
			GuessingPanelReferences.instance.RoundText.text = "Guessing Round";         
			GuessingPanelReferences.instance.Guess.text = "";

            var drawing = new Texture2D(2, 2);
            drawing.LoadImage(node.Drawing);

            var size = DrawingPanelReferences.instance.Capture.GetTextureSize();         
            TextureScale.Bilinear(drawing, (int)size.x, (int)size.y);         

			GuessingPanelReferences.instance.Capture.SetImage(drawing);         
            DrawingPanelReferences.instance.RoundText.gameObject.SetActive(true);

            base.StartRound();
        }

        /// <summary>
        /// Hides UI and takes a screenshot.
        /// </summary>
        public override void EndRound()
        {
            if (!IsRunning) return;
         
            if (Timer.instance.gameObject.GetActive())
            {
                Timer.instance.StopTimer();
            }
            
            base.EndRound();

			SendData();
        }

        /// <summary>
        /// Hide word text, enable drawing
        /// </summary>
        public override void OnCountdownFinish()
        {
			GuessingPanelReferences.instance.RoundText.gameObject.SetActive(false);

            base.OnCountdownFinish();
        }
      
        /// <summary>
        /// Sends word data
        /// </summary>
        void SendData()
        {
			var node = new StackNode(PhotonNetwork.player.ID, GuessingPanelReferences.instance.Guess.text);
			var nodeBytes = ByteSerializer<StackNode>.Serialize(node);

			GameData.instance.LocalView.RPC("SendNode", PhotonTargets.All, GameData.instance.CurrentIndex, nodeBytes);
        }
    }
}