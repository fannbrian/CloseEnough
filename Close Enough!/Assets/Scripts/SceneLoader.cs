using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Load a specific scene
/// 
/// Param: scene -- Name
/// </summary>
public class SceneLoader : MonoBehaviour {
	public void LoadScene(string scene)
	{
        SceneManager.LoadSceneAsync(scene);
	}

    public void PhotonLoad(string scene)
    {
        if (PhotonNetwork.isMasterClient)
        {
            PhotonNetwork.room.IsOpen = false;
            PhotonNetwork.LoadLevel(scene);
        }
    }
}
