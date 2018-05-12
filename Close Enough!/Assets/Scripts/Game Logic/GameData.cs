using UnityEngine;

namespace CloseEnough
{
	public class GameData : MonoBehaviour
	{
        public static GameData instance;

        public GameData()
        {
            instance = this;
        }

		public PhotonView LocalView;
		public int PlayerCount;
		public int CurrentRound;
		public string PlayerNames = "";
		public int[] PlayerOrder;
		public DrawingStack[] DrawingStacks;
		public DrawingStack CurrentStack;
		public int InitialIndex;
		public int PlayersDone;
	}
}