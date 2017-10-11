using System;

namespace NCDSL.TreeStructures
{	
	public class RedBlackTreeNode<T> : BinaryTreeNode<T>, IRedBlackNode<T>
	{	
		public bool IsRed { get; set; }
	}		
	
}

