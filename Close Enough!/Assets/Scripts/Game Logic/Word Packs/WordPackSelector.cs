using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CloseEnough
{
	public class WordPackSelector : MonoBehaviour
	{
		public WordPackObject[] WordPacks;

		void Awake()
		{
			WordBank.WordPacks.Add(WordPacks[0]);
		}
	}
}
