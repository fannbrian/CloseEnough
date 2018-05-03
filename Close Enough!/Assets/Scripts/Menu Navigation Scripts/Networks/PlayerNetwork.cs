using UnityEngine;
using UnityEngine.UI;

public class PlayerNetwork : MonoBehaviour {

	public Text nameInput;
	public static PlayerNetwork Instance;
	public string PlayerName { get; set; }

	private void Awake()
	{
		Instance = this;
		PlayerName = "Testing#" + Random.Range (1000, 9999);
	}

	public void SetNickname(){
		PlayerName = nameInput.text + "#" + Random.Range (1000, 9999);
	}
}
