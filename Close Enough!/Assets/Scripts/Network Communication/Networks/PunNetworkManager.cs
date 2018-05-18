using UnityEngine;
using Photon;

namespace CloseEnough
{
    /// <summary>
    /// Handles automated connecting to Photon servers
    /// <para>
    /// @Author: Alex Berthon, Brian Fann
    /// @Updated: 5/4/18
    /// </para>
    /// </summary>
    public class PunNetworkManager : PunBehaviour
    {
		public GameObject TitlePanel;
        public GameObject NicknamePanel;
        public GameObject LobbyPanel;
        public PlayerLayoutGroup playerLayout;

        public PunNetworkManager singleton;
        public float ReconnectDelay;

        public bool IsReconnecting { get; private set; }

        private float _timeElapsed = 0;

        public PunNetworkManager()
        {
            singleton = this;
        }

        void Connect()
        {         
            PhotonNetwork.ConnectUsingSettings("v1");
            PhotonNetwork.automaticallySyncScene = true;
            PhotonNetwork.autoJoinLobby = false;

			if (NetworkRejoinData.instance == null) return;
			if (!NetworkRejoinData.instance.isReconnecting) return;

			Debug.Log("Detected previous match.");
        }

        void Awake()
        {
            print("Connecting to server..");
            Connect();
        }

        // If not connected, periodically try to connect.
        void Update()
        {
			if (PhotonNetwork.connectedAndReady) return;

            _timeElapsed += Time.deltaTime;

            if (_timeElapsed < ReconnectDelay) return;

            print("Attempting to connect to server..");
            _timeElapsed = 0;
            Connect();
        }

		public override void OnConnectedToMaster()
		{
            base.OnConnectedToMaster();
			if (NetworkRejoinData.instance == null) return;
			if (!NetworkRejoinData.instance.isReconnecting) return;

			NetworkRejoinData.instance.isReconnecting = false;
			Debug.Log("Reconnected");

            var settings = new RoomOptions()
            {
                MaxPlayers = 10,
                IsVisible = false
            };

			PhotonNetwork.player.NickName = NetworkRejoinData.instance.PlayerName;
			PhotonNetwork.JoinOrCreateRoom(NetworkRejoinData.instance.RoomCode, settings, new TypedLobby());
            
			TitlePanel.gameObject.SetActive(false);
			NicknamePanel.gameObject.SetActive(false);
			LobbyPanel.gameObject.SetActive(true);

			DisplayRoomCode.instance.SetRoomName(NetworkRejoinData.instance.RoomCode);
   		}
	}
}