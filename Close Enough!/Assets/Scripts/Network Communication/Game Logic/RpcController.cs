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
			GameData.DrawingStacks = ByteSerializer<DrawingStack[]>.Deserialize(nodeBytes);
			GameData.PlayerOrder = order;

			foreach(var stack in GameData.DrawingStacks) {
				foreach(var node in stack.Nodes) {
					Debug.Log(node.Owner + ": " + node.Type + ", " + node.Word);
				}
			}

			var orderString = "";
			foreach(var player in order) {
				orderString += player + "-";
			}
			Debug.Log(orderString);

		}

        [PunRPC]
		public void SendNode(byte[] nodeBytes) {
			var node = ByteSerializer<StackNode>.Deserialize(nodeBytes);
			var nodeData = node.Owner + ": " + node.Type + ", " + node.Word;
			GameData.PlayerNames += nodeData;
		}

		[PunRPC]
		public void GameLoaded() {
			GameData.PlayerCount++;
			if (PhotonNetwork.isMasterClient) {
				var gameHandler = InitialGameHandler.singleton;

				if (gameHandler == null) return;

				gameHandler.TryStartGame();
			}
		}
	}
}