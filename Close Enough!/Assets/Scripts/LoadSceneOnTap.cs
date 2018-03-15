using UnityEngine;
using UnityEngine.SceneManagement;

namespace CloseEnough {
    public class LoadSceneOnTap : MonoBehaviour
    {
        public string SceneToLoad;

        void Update()
        {
            var touch = Input.touches;

            if (touch.Length <= 0) return;

            SceneManager.LoadSceneAsync(SceneToLoad);
        }
    }
}