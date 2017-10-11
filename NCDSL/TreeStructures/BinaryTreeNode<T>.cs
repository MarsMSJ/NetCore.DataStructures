using System;
using System.Collections.Generic;

namespace NCDSL.TreeStructures
{
	public class BinaryTreeNode<T> : ITreeNode<T>
	{	
		public BinaryTreeNode<T> RightChild { get; set; }
		public BinaryTreeNode<T> LeftChild { get; set; }		
		public ITreeNode<T> Parent { get; set; }
		public T Value { get; set; }
		
		public ICollection<ITreeNode<T>> Children { 
			get => (	new ITreeNode<T>[]{ LeftChild, RightChild } ); 
		}
			
		public BinaryTreeNode( ) : base( ) { }		
	}	
}

