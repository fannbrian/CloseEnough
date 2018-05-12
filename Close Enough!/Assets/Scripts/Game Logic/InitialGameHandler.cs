using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace CloseEnough
{
	/// <summary>
    /// Handles initializing the game.
    /// </summary>
	public class InitialGameHandler
	{
		public static InitialGameHandler singleton;

		public InitialGameHandler() {
			singleton = this;
		}

        /// <summary>
        /// Initializes initial game data and sends it to every player.
        /// </summary>
		public void InitializeGame() {
			Debug.Log("Initializing Game");
			var playerList = PhotonNetwork.playerList;
			var playerCount = playerList.Length;
			var playerIds = new int[playerCount];

			for (int i = 0; i < playerCount; i++) {
				playerIds[i] = playerList[i].ID;
			}
         
            // Randomize player order
			var rnd = new System.Random();
			var order = playerIds.OrderBy(x => rnd.Next()).ToArray();

            // Initialize word for each player
			var wordList = new List<string>();

			for (int i = 0; i < playerCount; i++) {
				var word = "";

				do
				{
					word = WordBank.WORDS[rnd.Next(WordBank.WORDS.Length)];
				} while (wordList.Contains(word));

				wordList.Add(word);
			}

            // Initialize the drawing stacks
			var stacks = new DrawingStack[playerCount];

			for (int i = 0; i < playerCount; i++) {
				var node = new StackNode(order[i], wordList[i]);
                stacks[i] = new DrawingStack();
				stacks[i].Nodes.Add(node);
			}
			GameData.instance.LocalView.RPC("StartGame", PhotonTargets.AllBufferedViaServer, order, ByteSerializer<DrawingStack[]>.Serialize(stacks));
		}

        // Starts the game if every player is connected.
		public void TryStartGame()
		{
            Debug.Log(GameData.instance.PlayerCount + ", " + PhotonNetwork.playerList.Length);
			if (GameData.instance.PlayerCount == PhotonNetwork.playerList.Length)
			{
				InitializeGame();
			}
		}
	}
}