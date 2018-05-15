using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CloseEnough
{
	[CreateAssetMenu(fileName = "WordPack", menuName = "Word Pack", order = 0)]
	public class WordPackObject : ScriptableObject
	{
		public string Name;
		public string[] Words;
	}
}