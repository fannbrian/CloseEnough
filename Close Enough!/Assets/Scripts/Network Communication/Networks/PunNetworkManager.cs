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
        public GameObject NicknamePanel;
        public GameObject LobbyPanel;
        public PlayerLayoutGroup playerLayout;

        public PunNetworkManager singleton;
        public float ReconnectDelay;

        public bool IsConnected { get; private set; }

        private float _timeElapsed = 0;

        public PunNetworkManager()
        {
            IsConnected = true;
            singleton = this;
        }

        private void Connect()
        {
            PhotonNetwork.ConnectUsingSettings("0.0.0");
            PhotonNetwork.automaticallySyncScene = true;
            PhotonNetwork.autoJoinLobby = false;
        }

        private void Awake()
        {
            print("Connecting to server..");
            Connect();
        }

        // If not connected, periodically try to connect.
        private void Update()
        {
            if (IsConnected) return;

            _timeElapsed += Time.deltaTime;

            if (_timeElapsed < ReconnectDelay) return;

            print("Attempting to connect to server..");
            _timeElapsed = 0;
            Connect();
        }

		/// <summary>
		/// If connection to photon failed, set IsConnected to false.
		/// </summary>
		/// <param name="cause">Cause.</param>
		public override void OnFailedToConnectToPhoton(DisconnectCause cause)
        {
            IsConnected = false;
            base.OnFailedToConnectToPhoton(cause);
        }


        /// <summary>
        /// If connection failed, set IsConnected to false.
        /// </summary>
        /// <param name="cause">Cause.</param>
        public override void OnConnectionFail(DisconnectCause cause)
        {
            IsConnected = false;
            base.OnConnectionFail(cause);
        }


        /// <summary>
        /// If disconnected, set IsConnected to false.
        /// </summary>
        /// <param name="cause">Cause.</param>
        public override void OnDisconnectedFromPhoton()
        {
            IsConnected = false;
            base.OnDisconnectedFromPhoton();
        }

        public override void OnConnectedToMaster()
        {
            IsConnected = true;
            base.OnConnectedToMaster();
        }
    }
}