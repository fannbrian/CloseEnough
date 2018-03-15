using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CloseEnough{
    [RequireComponent(typeof(Image))]
    public class RandomDoodle : MonoBehaviour
    {
        public float maxChangeDelay;
        public float minChangeDelay;
        public float maxAngleOffset;

        float _changeDelay;
        float _lastChanged;
        Object[] _sprites;
        Image _img;

        void Start()
        {
            _sprites = Resources.LoadAll("Art/Doodlesheet");
            _img = GetComponent<Image>();
            _lastChanged = Time.time;
            _changeDelay = Random.Range(minChangeDelay, maxChangeDelay);
            var index = Random.Range(1, _sprites.Length);

            try {
                _img.sprite = (Sprite)_sprites[index];
            }
            catch(System.InvalidCastException e) {
                Debug.Log("InvalidCastException at index " +index+" from a set of size "+_sprites.Length);
            }
        }

        void Update()
        {
            if ((_lastChanged + _changeDelay) > Time.time) return;

            var angleOffset = Random.Range(-maxAngleOffset, maxAngleOffset);

            _lastChanged = Time.time;

            transform.rotation = Quaternion.Euler(new Vector3(0,0,angleOffset));
        }
    }
}