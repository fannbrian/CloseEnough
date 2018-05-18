using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CloseEnough
{
	/// <summary>
	/// Initializes word bank to the selected word packs
	/// </summary>
	public class WordPackSelector : MonoBehaviour
	{
		public WordPackObject[] WordPacks;

		void Awake()
		{
			WordBank.WordPacks.Add(WordPacks[0]);
		}
	}
}
