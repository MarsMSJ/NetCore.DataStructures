using System;
using System.Collections.Generic;

namespace NCDSL.TreeStructures
{
	public interface ITreeNode<T>{
		
		T Value { get; set; }
		ITreeNode<T> Parent { get; set; }
		ICollection<ITreeNode<T>> Children { get; }
	}
}