using UnityEngine;
using UnityEngine.SceneManagement;

namespace CloseEnough
{
    /// <summary>
    /// Load scene on tap. ASdfgajdmifjdo
    /// </summary>
    public class LoadSceneOnTap : MonoBehaviour
    {
        public string SceneToLoad;

        /// <summary>
        /// Update this instance.
        /// </summary>
        void Update()
        {
#if UNITY_IOS || UNITY_ANDROID
            var touch = Input.touches;

            if (touch.Length <= 0) return;
#elif UNITY_EDITOR
            if (!Input.GetMouseButtonDown(0)) return;
#endif
            SceneManager.LoadSceneAsync(SceneToLoad);
        }
    }
}