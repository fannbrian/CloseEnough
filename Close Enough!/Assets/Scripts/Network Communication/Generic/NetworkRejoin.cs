namespace CloseEnough
{
	public class NetworkRejoinData
	{
		public static NetworkRejoinData instance;
		public string PlayerName;
		public string RoomCode;

		public NetworkRejoinData(string name, string code) {
			instance = this;
			PlayerName = name;
			RoomCode = code;
		}
	}
}