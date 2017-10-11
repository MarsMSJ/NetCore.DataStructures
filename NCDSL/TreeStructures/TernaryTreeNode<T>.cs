using System;
using System.Collections.Generic;

namespace NCDSL.TreeStructures
{
	public class TernaryTreeNode<T> : ITreeNode<T>
	{	
		public TernaryTreeNode<T> LeftChild { get; set; }
		public TernaryTreeNode<T> MiddleChild { get; set; }	
		public TernaryTreeNode<T> RightChild { get; set; }	
		public ITreeNode<T> Parent { get; set; }
		public T Value { get; set; }
		
		public ICollection<ITreeNode<T>> Children { 
			get => (	
				new ITreeNode<T>[]{ LeftChild, MiddleChild, RightChild } ); 
		}
			
		public TernaryTreeNode( ) : base( ) { }		

	}	
}

