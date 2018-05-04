using UnityEngine;
using UnityEngine.UI;

public class PlayerNetwork : MonoBehaviour {

	public Text nameInput;
	public static PlayerNetwork Instance;
	public string PlayerName { get; set; }

	void Awake()
	{
		Instance = this;
		Instance.PlayerName = "Meow";
	}

	public void SetNickname(){
		Instance.PlayerName = nameInput.text;
        PhotonNetwork.playerName = Instance.PlayerName;
        Debug.Log("SET: " + Instance.PlayerName);
	}
}
