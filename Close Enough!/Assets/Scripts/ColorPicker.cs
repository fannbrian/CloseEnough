using UnityEngine;

namespace CloseEnough
{
    public class ColorPicker : MonoBehaviour
    {
        public Renderer rend;

        // Use this for initialization
        void Start()
        {
            rend = GetComponent<Renderer>();
            rend.enabled = true;
            rend.sharedMaterial = ColorManager.singleton.CurrentColor;
        }
    }
}