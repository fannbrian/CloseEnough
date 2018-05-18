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

		const int ASCII_OFFSET = 65;
        const int ALPHABET_COUNT = 26;
        
        string GenerateRoomCode()
        {
            var rand = new System.Random();
            var code = new int[] {
                rand.Next(ALPHABET_COUNT),
                rand.Next(ALPHABET_COUNT),
                rand.Next(ALPHABET_COUNT),
                rand.Next(ALPHABET_COUNT),
            };
            var roomCode = "";

            foreach (var num in code)
            {
                roomCode += (char)(num + ASCII_OFFSET);
            }

            return roomCode;
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
			var order = playerIds.OrderBy(x => Random.Range(0, playerCount)).ToArray();

            // Initialize word for each player
			var wordList = new List<string>();

			for (int i = 0; i < playerCount; i++) {
				var word = "";

				do
				{
					word = WordBank.Words[Random.Range(0, WordBank.Words.Length)];
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
			GameData.instance.LocalView.RPC("StartGame", PhotonTargets.AllBufferedViaServer, order, ByteSerializer<DrawingStack[]>.Serialize(stacks), GenerateRoomCode());
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