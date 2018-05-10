using UnityEngine;

public class NetworkTest : MonoBehaviour {
	void Start () {
		var view = PhotonNetwork.Instantiate("PhotonPlayer", Vector3.zero, Quaternion.identity, 0).GetPhotonView();
		view.RPC("ImHere", PhotonTargets.All);
	}
	[PunRPC]
	public void ImHere() {
		Debug.Log("I AM HERE!!!");
	}
}
