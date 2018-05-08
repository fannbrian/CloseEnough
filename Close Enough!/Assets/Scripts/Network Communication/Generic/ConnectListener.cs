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
    public class ConnectListener : PunBehaviour
    {
        // Action to fire off
        public UnityEvent OnConnect;

        /// <summary>
        /// Photon Unity Networking's method when the player joins a room (master or client)
        /// </summary>
        public override void OnConnectedToMaster()
        {
            OnConnect.Invoke();
            base.OnConnectedToMaster();
        }
    }
}