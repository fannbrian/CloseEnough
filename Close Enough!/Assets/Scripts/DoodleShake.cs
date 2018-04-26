using UnityEngine;
using UnityEngine.UI;

namespace CloseEnough
{
    /// <summary>
    /// Adds a "shake" effect to 
    /// </summary>
    [RequireComponent(typeof(Image))]
    public class DoodleShake : MonoBehaviour
    {
        public float maxChangeDelay = 1f;
        public float minChangeDelay = 0.25f;
        public float maxAngleOffset = 45;

        float _changeDelay;
        float _lastChanged;
        Image _img;

        void Start()
        {
            _img = GetComponent<Image>();
            _lastChanged = Time.time;
            _changeDelay = Random.Range(minChangeDelay, maxChangeDelay);
        }

        void Update()
        {
            if ((_lastChanged + _changeDelay) > Time.time) return;

            var angleOffset = Random.Range(-maxAngleOffset, maxAngleOffset);

            _lastChanged = Time.time;

            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angleOffset));
        }
    }
}