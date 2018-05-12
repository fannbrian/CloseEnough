using UnityEngine;

namespace CloseEnough
{
	/// <summary>
    /// Hides a game object if the player is not the host.
	/// <para>
	/// @Author: Brian Fann
	/// @Last Updated: 5/9/18
	/// </para>
    /// </summary>
	public class HideIfNotMaster : MonoBehaviour
	{
        public GameObject ObjectToHide;

		void Update()
		{
			if (!PhotonNetwork.isMasterClient)
			{
				ObjectToHide.SetActive(false);
			}
			else {            
                ObjectToHide.SetActive(true);
			}
		}
	}
}