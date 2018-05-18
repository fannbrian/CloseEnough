using UnityEngine;
using System.Collections.Generic;

namespace CloseEnough
{
	/// <summary>
    /// Routes RPC calls to the appropriate services.
	/// 
	/// <para>
	/// @Author: Brian Fann
	/// @Last Updated: 5/9/18
	/// </para>
    /// </summary>
	public class RpcController : MonoBehaviour
	{
		/// <summary>
        /// Initializes game data for all players once game starts
        /// </summary>
        /// <param name="order">Order of players</param>
		/// <param name="nodeBytes">Serialized node data (with the initial nodes)</param>
        /// <param name="nextRoomCode">Next room code to join to once game is over.</param>
		[PunRPC]
		public void StartGame(int[] order, byte[] nodeBytes, string nextRoomCode) {
			GameData.instance.DrawingStacks = ByteSerializer<DrawingStack[]>.Deserialize(nodeBytes);
			GameData.instance.PlayerOrder = order;

			NetworkRejoinData.instance = new NetworkRejoinData(PhotonNetwork.player.NickName, nextRoomCode);
            
			for (int i = 0; i < order.Length; i++) {
				if (order[i] == PhotonNetwork.player.ID) {
					GameData.instance.InitialIndex = i;
				}
			}

			foreach(var stack in GameData.instance.DrawingStacks) {
				foreach(var node in stack.Nodes) {
					Debug.Log(node.Owner + ": " + node.Type + ", " + node.Word);
				}
			}

			var orderString = "";
			foreach(var player in order) {
				orderString += player + "-";
			}

			GameStateManager.singleton.TransitionNextState();
		}

        /// <summary>
        /// Sends a stack node to all players
		/// <para>
		/// @Author: Brian Fann
		/// @Last Updated: 5/12/18
		/// </para>
        /// </summary>
        /// <param name="index">Index of stack node.</param>
        /// <param name="nodeBytes">Serialized node data.</param>
        [PunRPC]
		public void SendNode(int index, byte[] nodeBytes) {
			Debug.Log("RECEIVED DATA");
			var node = ByteSerializer<StackNode>.Deserialize(nodeBytes);
			GameData.instance.DrawingStacks[index].Nodes.Add(node);
			GameData.instance.PlayersDone++;
			if (GameData.instance.PlayersDone >= GameData.instance.PlayerCount) {
				Debug.Log("ALL PLAYERS DONE");
				GameData.instance.PlayersDone = 0;
                GameData.instance.CurrentRound++;
				GameStateManager.singleton.TransitionNextState();
			}
		}


        /// <summary>
        /// Alerts master that this client has loaded and attempt to start the game.
        /// <para>
        /// @Author: Brian Fann
        /// @Last Updated: 5/12/18
        /// </para>
        /// </summary>
        /// <param name="index">Index of stack node.</param>
        /// <param name="nodeBytes">Serialized node data.</param>
		[PunRPC]
		public void GameLoaded() {
			GameData.instance.PlayerCount++;
			if (PhotonNetwork.isMasterClient) {
				var gameHandler = InitialGameHandler.singleton;
                
				if (gameHandler == null) return;
                
                gameHandler.TryStartGame();
			}
		}
	}
}