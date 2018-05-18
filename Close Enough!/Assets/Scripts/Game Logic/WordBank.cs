using System.Collections.Generic;

namespace CloseEnough {
	/// <summary>
	/// Creates a word bank based on given words
	/// </summary>
	public class WordBank
	{
		public static string[] Words {
			get {
				var wordBank = new HashSet<string>();
                
				foreach(var pack in WordPacks) {
					foreach(var word in pack.Words) {
						wordBank.Add(word);
					}
				}

				var result = new string[wordBank.Count];
				wordBank.CopyTo(result);

				return result;
			}
		}

		public static List<WordPackObject> WordPacks = new List<WordPackObject>();
	}
}