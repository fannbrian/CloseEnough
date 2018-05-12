using Photon;
using UnityEngine.Events;

namespace CloseEnough
{
    /// <summary>
    /// Event listener wrapped around Photon's OnJoinedRoom() event.
    /// 
    /// <para>
    /// @Author: Brian Fann
    /// @Updated: 5/4/18
    /// </para>
    /// </summary>
    public class ConnectFailListener : PunBehaviour
    {
        // Action to fire off
        public UnityEvent OnFailConnect;

        public void OnCreateFail()
        {
            OnFailConnect.Invoke();
        }

        /// <summary>
        /// Photon Unity Networking's method when the player joins a room (master or client)
        /// </summary>
        public override void OnConnectionFail(DisconnectCause cause)
        {
            OnFailConnect.Invoke();
            base.OnConnectionFail(cause);
        }

        public override void OnPhotonJoinRoomFailed(object[] codeAndMsg)
        {
            OnFailConnect.Invoke();
            base.OnPhotonJoinRoomFailed(codeAndMsg);
        }
    }
}