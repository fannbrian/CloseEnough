using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CloseEnough
{
	[RequireComponent(typeof(InputField))]
	public class RoomCodeValidation : MonoBehaviour
	{
		
		public InputField field;
		void Awake()
		{
			field = GetComponent<InputField>();
			field.onValidateInput += delegate (string input, int charIndex, char addedChar) { return Validate(addedChar); };
		}

        /// <summary>
        /// Only allow uppercase letters.
        /// </summary>
        /// <returns>The validate.</returns>
        /// <param name="input">Input.</param>
		char Validate(char input) {
			var ascii = (int)input;
			if (ascii >= 97 && ascii <= 122) {
				// Sets character to uppercase.
				input = (char)(ascii - 32);
			}
			else if (ascii >= 65 && ascii <= 90) {
				// Do nothing
			}
			else {
				// Return empty character if not alphabetical char
				input = '\0';
			}
			return input;
		}
	}
}