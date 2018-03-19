using UnityEngine;

namespace CloseEnough
{
    /// <summary>
    /// Allows the inspector to modify size values and handles size calculations.
    /// </summary>
    public class SizeManager : MonoBehaviour
    {
        public static SizeManager singleton;

        public float currentSize = 0.5f;

        public float minIconSize = 0.10f;
        public float maxIconSize = 0.75f;

        public float minStrokeSize = 0.0001f;
        public float maxStrokeSize = 0.0002f;

        public GameObject icon;

        public float GetIconSize()
        {
            var diff = maxIconSize - minIconSize;
            return minIconSize + diff * currentSize;
        }

        public float GetStrokeSize()
        {
            var diff = maxStrokeSize - minStrokeSize;
            return minStrokeSize + diff * currentSize;
        }

        void UpdateIcon()
        {
            var iconSize = GetIconSize();
            icon.transform.localScale = new Vector3(iconSize, iconSize);
        }

        void Start()
        {
            singleton = this;
            UpdateIcon();
        }

        public void SetSize(float size)
        {
            currentSize = size;
            UpdateIcon();
        }
    }
}