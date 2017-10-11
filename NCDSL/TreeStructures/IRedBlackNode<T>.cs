using System;

namespace NCDSL.TreeStructures
{
	public interface IRedBlackNode<T> : ITreeNode<T>{		
		bool IsRed { get; set; }		
	}
}