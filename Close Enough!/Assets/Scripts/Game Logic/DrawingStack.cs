using System;
using System.Collections.Generic;

namespace CloseEnough
{
	/// <summary>
	/// Data container for the stack of words/drawings
	/// <para>
	/// @Author: Brian Fann
	/// @Updated: 5/9/18
	/// </para>
	/// </summary>
	[Serializable]
	public class DrawingStack
	{
		public IList<StackNode> Nodes;

		public DrawingStack() {
			Nodes = new List<StackNode>();
		}
	}
   
	[Serializable]
	public class StackNode {
		public int Owner;
		public string Type;
		public string Word;
		public byte[] Drawing;

		public static StackNode InitialNode(int owner, string word) {
			var node = new StackNode(owner, word);
			node.Type = DrawingStackConstants.TYPE_INITIAL;
			return node;
		}

		public StackNode(int owner, string word) {
			Owner = owner;
			Type = DrawingStackConstants.TYPE_WORD;
			Word = word;
		}

		public StackNode(int owner, byte[] drawing) {
			Owner = owner;
			Type = DrawingStackConstants.TYPE_DRAWING;
			Drawing = drawing;
		}
	}
   
	public static class DrawingStackConstants {
		public const string TYPE_INITIAL = "Initial";
		public const string TYPE_DRAWING = "Drawing";
		public const string TYPE_WORD = "Word";
	}
}
