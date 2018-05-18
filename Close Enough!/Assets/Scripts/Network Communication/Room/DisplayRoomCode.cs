using UnityEngine;
using UnityEngine.UI;

namespace CloseEnough
{
	public class DisplayRoomCode : MonoBehaviour
	{
		public static DisplayRoomCode instance;
		public Text roomName;

		public DisplayRoomCode()
		{
			instance = this;
		}

		void OnEnable()
		{
			if (PhotonNetwork.room.Name.Length > 0)
			{
				roomName.text = "Room Code: " + PhotonNetwork.room.Name;
			}
			else
			{
				roomName.text = "Error retrieving room ID";
			}
		}

		public void SetRoomName(string name)
		{
			roomName.text = "Room Code: " + name;
		}
	}
}