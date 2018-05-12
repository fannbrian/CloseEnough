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
		[PunRPC]
		public void StartGame(int[] order, byte[] nodeBytes) {
			GameData.instance.DrawingStacks = ByteSerializer<DrawingStack[]>.Deserialize(nodeBytes);
			GameData.instance.PlayerOrder = order;
            
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

        [PunRPC]
		public void SendNode(int index, byte[] nodeBytes) {
			var node = ByteSerializer<StackNode>.Deserialize(nodeBytes);
			GameData.instance.DrawingStacks[index].Nodes.Add(node);
			GameData.instance.PlayersDone++;
			if (GameData.instance.PlayersDone >= GameData.instance.PlayerCount) {
                GameData.instance.CurrentRound++;
				GameStateManager.singleton.TransitionNextState();
			}
		}

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