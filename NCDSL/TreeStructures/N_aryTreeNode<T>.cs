using System;
using System.Collections.Generic;

namespace NCDSL.TreeStructures
{
	public class N_aryTreeNode<T> : ITreeNode<T>
	{			
		public ITreeNode<T> Parent { get; set; }
		public T Value { get; set; }
		
		public ICollection<ITreeNode<T>> Children { 
			get => (ICollection<ITreeNode<T>>)Children_; 
		}
			
		public N_aryTreeNode( ) : base( ) 
		{
			Children_ = new List<N_aryTreeNode<T>>();	
		}		
		
		List<N_aryTreeNode<T>> Children_;	

	}	
}