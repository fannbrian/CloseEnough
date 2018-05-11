using System.Collections.Generic;

namespace CloseEnough
{
	public static class GameData
	{
		public static PhotonView LocalView;
		public static int PlayerCount;
		public static int CurrentRound;
		public static string PlayerNames = "";
		public static int[] PlayerOrder;
		public static DrawingStack[] DrawingStacks;
		public static DrawingStack CurrentStack;
		public static int InitialIndex;
		public static int PlayersDone;
	}
}