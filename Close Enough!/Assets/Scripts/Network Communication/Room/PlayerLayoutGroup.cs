using System.Collections.Generic;
using UnityEngine;
using Photon;

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
        
        public void InitializeRoom()
        {
            while (PlayerListings.Count > 0)
            {
                Destroy(PlayerListings[0].gameObject);
                PlayerListings.RemoveAt(0);
            }
            PhotonPlayer[] photonPlayers = PhotonNetwork.playerList;
            for (int i = 0; i < photonPlayers.Length; i++)
            {
                PlayerJoinedRoom(photonPlayers[i]);
            }
        }

        //called by photon
        public override void OnPhotonPlayerConnected(PhotonPlayer photonPlayer)
        {
            PlayerJoinedRoom(photonPlayer);
        }

        //called by photon
        public override void OnPhotonPlayerDisconnected(PhotonPlayer photonPlayer)
        {
            PlayerLeftRoom(photonPlayer);
        }


        private void PlayerJoinedRoom(PhotonPlayer photonPlayer)
        {
            if (photonPlayer == null)
                return;

            PlayerLeftRoom(photonPlayer);

            GameObject playerListingObj = Instantiate(PlayerListingPrefab);
            playerListingObj.transform.SetParent(transform, false);

            PlayerListing playerListing = playerListingObj.GetComponent<PlayerListing>();
            playerListing.ApplyPhotonPlayer(photonPlayer);

            PlayerListings.Add(playerListing);
        }

        private void PlayerLeftRoom(PhotonPlayer photonPlayer)
        {
            int index = PlayerListings.FindIndex(x => x.PhotonPlayer == photonPlayer);
            if (index != -1)
            {
                Destroy(PlayerListings[index].gameObject);
                PlayerListings.RemoveAt(index);
            }
        }

        public void OnClickLeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }
    }
}