using UnityEngine;
using UnityEngine.SceneManagement;

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
