using System.Collections.Generic;
using UnityEngine;
using Photon;
using System.Linq;

namespace CloseEnough
{
    /// <summary>
    /// Handler for how players are displayed in a room
    /// <para>
    /// @Author: Alex Berthon
    /// @Updated: 5/2/18
    /// </para>
    /// </summary>
    public class PlayerLayoutGroup : PunBehaviour
    {
		public PlayerLayoutGroup instance;

        [SerializeField]
        private GameObject _playerListingPrefab;
        private GameObject PlayerListingPrefab
        {
            get { return _playerListingPrefab; }
        }

        private List<PlayerListing> _playerListings = new List<PlayerListing>();
        private List<PlayerListing> PlayerListings
        {
            get { return _playerListings; }
        }

		void OnEnable()
		{
			instance = this;
			UpdateRoom();
		}

		public void UpdateRoom()
        {
            while (PlayerListings.Count > 0)
            {
                Destroy(PlayerListings[0].gameObject);
                PlayerListings.RemoveAt(0);
            }

			PhotonPlayer[] photonPlayers = PhotonNetwork.playerList.OrderBy(p => p.ID).ToArray();

            for (int i = 0; i < photonPlayers.Length; i++)
            {
                PlayerJoinedRoom(photonPlayers[i]);
            }
        }

		//called by photon
		public override void OnPhotonPlayerConnected(PhotonPlayer photonPlayer)
        {
			Debug.Log("A friend has arrived");
			UpdateRoom();
        }

        //called by photon
        public override void OnPhotonPlayerDisconnected(PhotonPlayer photonPlayer)
        {
			UpdateRoom();
        }

		public override void OnMasterClientSwitched(PhotonPlayer newMasterClient)
		{
			UpdateRoom();
			base.OnMasterClientSwitched(newMasterClient);
		}


		void PlayerJoinedRoom(PhotonPlayer photonPlayer)
        {
			if (photonPlayer == null)
			{
				return;
			}         
            GameObject playerListingObj = Instantiate(PlayerListingPrefab);
            playerListingObj.transform.SetParent(transform, false);

            PlayerListing playerListing = playerListingObj.GetComponent<PlayerListing>();
            playerListing.ApplyPhotonPlayer(photonPlayer);

            PlayerListings.Add(playerListing);
        }
      
        public void OnClickLeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }
    }
}