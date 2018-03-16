using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CloseEnough{
    [RequireComponent(typeof(Image))]
    public class RandomDoodle : MonoBehaviour
    {
        public static List<Object> Sprites { get; set; }
        public string SpritesheetPath = "Art/Doodlesheet";

        void Start()
        {
            if (Sprites == null)
            {
                Sprites = new List<Object>();
                Sprites.AddRange(Resources.LoadAll(SpritesheetPath));
            }

            var img = GetComponent<Image>();
            var index = Random.Range(1, Sprites.Count);

            // Try to set the image to a random sprite, and then remove the sprite from the list to make it unique.
            try {
                img.sprite = (Sprite)Sprites[index];
                Sprites.RemoveAt(index);
            }
            catch(System.InvalidCastException e) {
                Debug.Log("InvalidCastException at index " +index+" from a set of size "+Sprites.Count);
            }
        }

    }
}