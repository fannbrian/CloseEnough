using UnityEngine;
using UnityEngine.UI;
namespace CloseEnough
{
    /// <summary>
    /// Allows management/setting of colors from the inspector.
    /// </summary>
    public class ColorManager : MonoBehaviour
    {
        public static ColorManager singleton;
        public ColorOption[] Colors;
        public Material CurrentColor;
        public Image FillImage;

        void Start()
        {
            singleton = this;
            CurrentColor = Colors[0].Color;
        }

        public void SetColor(string color)
        {
            foreach (var option in Colors)
            {
                if (!option.Name.Equals(color)) continue;

                CurrentColor = option.Color;
                FillImage.material = option.Color;
            }
        }
    }
}
