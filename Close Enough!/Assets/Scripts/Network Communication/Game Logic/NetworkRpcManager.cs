using UnityEngine;
using Photon;

namespace CloseEnough
{
    public class NetworkRpcManager : PunBehaviour
    {
        private int playerCount = 0;

        [PunRPC]
        public void ClientJoinedMatch()
        {
            if (PhotonNetwork.isMasterClient)
            {
                playerCount++;
                Debug.Log(playerCount);
            }
        }

        public void StartMatch()
        {

        }
    }
}