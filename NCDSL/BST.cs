using System;
using System.Linq;
using System.Collections.Generic;

namespace NCDSL.TreeStructures
{

/************************************************************
    Alias
*/
  using IntStrBuildDict = Dictionary<int, System.Text.StringBuilder>;    
  
  public class BST<T> where T : IComparable<T>, IEquatable<T>
  {

/************************************************************
    Private Members
*/
    uint Count_;
    Node<T> Root_;
    
    

/************************************************************
    Properties
      public uint Count
      ublic bool IsEmpty
*/

    public uint Count { get => Count_; }
    public bool IsEmpty { get => Count_ == 0; }

/************************************************************
    Functions: Modifyers
        public void Insert( T value )
        public void Remove( T value )
        public void Clear()
*/

    // O(LogN)
    public void Insert( T value )
    {
      //Case is empty
      if ( IsEmpty )
      {
        Root_ = new Node<T>( value );
        Count_++;
        return;
      }

      //Start by performing an unsuccessful search
      //keeping track of the parent node;

      var parent = Root_;
      var node = Root_;
      var newNode = new Node<T>( value );

      while( node != null )
      {
        parent = node;
        node = ( parent.Value.CompareTo( value ) > 0 ) ? node.Left : node.Right;
      }

      if( parent.Value.CompareTo( value ) > 0 )
      {
        parent.Left = newNode;
      }
      else
      {
        parent.Right = newNode;
      }

      Count_++;
    }

    //O(LogN)
    public void Remove( T value )
    {
      if( IsEmpty )
      {
        throw new Exception(BAD_CALL_EMPTY);
      }

      //Search for node with value
      //and it's parent
      var parent = Root_;
      var node = FindNode( value, out parent );

      Node<T> newChild = null;
      bool isLeftChild = false;

      //Local function to help with redundant parent clean up
      //Setting newChild to null effectively deletes the node
      void FixParent( )
      {
        if( isLeftChild )
        {
          parent.Left = newChild;
        }
        else
        {
          parent.Right = newChild;
        }
      }

      //Value is not in the BST
      if( node == null )
      {
        throw new Exception( BAD_CALL_NOTFOUND );
      }

      //Case: Node is a leaf
      if( node.IsLeaf )
      {
        newChild = null; //Effectively deletes the node from the parent
        FixParent( );
      }

      //Case: Node has one child (left or right )
      if( node.Right == null || node.Left == null )
      {
        newChild = ( node.Right == null ) ? node.Left : node.Right;
        FixParent();
      }
      else
      {
        //Case: Node has children
        var successor = FindSuccessorNode( node, out parent );
        node.Value = successor.Value;  //Swap values
        isLeftChild = true; //Successor will always be on the left of the parent
        newChild = null; //Effectively deletes the node from the parent
        FixParent( );
      }
      Count_--;
    }

// Clears the structure. GC handles the rest.
  //O(1)
  public void Clear()
  {
    Root_ = null;
    Count_ = 0;
  }



/************************************************************
Private Node Functions

  private Node<T> FindSuccessorNode( Node<T> node, out Node<T> parent )
  private Node<T> FindPredeccessor( Node<T> node, out Node<T> parent )
  private Node<T> FindNode( T value, out Node<T> parent )
*/

  // Returns null if the node has no right child
  // Node->Right == null
  //O(LogN)
    private Node<T> FindSuccessorNode( Node<T> node, out Node<T> parent )
    {
      if( IsEmpty )
      {
        throw new Exception(BAD_CALL_EMPTY);
      }

      parent = node;

      if( node.Right == null )
      {
        //Absense of a successor node
        return null;
      }

      //Move one node to the right
      node = node.Right;

      //Search for the smallest value in the right sub-tree
      while( node.Left != null )
      {
        parent = node;
        node = node.Left;
      }

      return node;
    }

    // Returns null if the node has no left child
    // Node->Left == null
    // O(LogN)

    private Node<T> FindPredeccessor( Node<T> node, out Node<T> parent )
    {
      if( IsEmpty )
      {
        throw new Exception(BAD_CALL_EMPTY);
      }

      parent = node;

      if( node.Right == null )
      {
        //Absense of a Predecessor node
        return null;
      }

      //Move one node to the left
      node = node.Left;

      //Search for the highest value in the left sub-tree
      while( node.Right != null )
      {
        parent = node;
        node = node.Right;
      }

      return node;
    }

    private Node<T> FindNode( T value, out Node<T> parent )
    {
      var node = Root_;
      parent = node;

      while( node != null  )
      {       
        if( node.Value.CompareTo( value ) == 0 )
        {
          break;
        }
        
        parent = node;
        node = ( node.Value.CompareTo( value ) > 0 ) ? node.Left : node.Right;
      }
      
      return node;
    }

    /************************************************************
    Getter Functions
      public T GetMax( T value )
      public T GetMin( T value )
      public IEnumerable<T> GetInOrder()
      public IEnumerable<T> GetPostOrder()
      public IEnumerable<T> GetPreOrder()
      public IEnumerable<T> GetInLevel()
			public IEnumerable<T> GetInOrder_NonRecursive()
      public IEnumerable<T> GetPostOrder_NonRecursive()
      public IEnumerable<T> GetPreOrder_NonRecursive()
    */

    public T GetMax(  )
    {
      if( IsEmpty )
      {
        throw new Exception(BAD_CALL_EMPTY);
      }

      var node = Root_;
      //Move to the furthest right node
      while( node.Right != null )
      {
        node = node.Right;
      }

      return node.Value;
    }

    public T GetMin( )
    {
      if( IsEmpty )
      {
        throw new Exception(BAD_CALL_EMPTY);
      }

      var node = Root_;
      //Move to the furthest left node
      while( node.Left != null )
      {
        node = node.Left;
      }

      return node.Value;
    }

    //O(N)
    public IEnumerable<T> GetInOrder()
    {
      var valueList = new List<T>();     
      InOrder( Root_, ref valueList );
      return valueList.AsEnumerable();
    }
    
    //O(N)
    public IEnumerable<T> GetInOrder_NonRecursive( )
    {   
      var stack = new Stack<Node<T>>();
      var valueList = new List<T>();    
      
      if( Root_ == null )
      {
        return valueList;
      }
      
      if( Root_.Right == null && Root_.Left == null )
      {
        valueList.Add( Root_.Value );
        return valueList;        
      }
       
      Node<T> node = Root_;
      stack.Push( Root_ );
     
      while( stack.Count != 0 )
      {
        node = stack.Peek();
        stack.Pop();
        
       while( node != null )
       {
         stack.Push( node );
         node = node.Left;
       }
       
       do
       {
         node = stack.Peek();
         stack.Pop();
         valueList.Add( node.Value );              
       }
       while( stack.Count > 0 && node.Right == null );
       
       if( node.Right != null )
       {
         stack.Push( node.Right );
       }
       
      }
     
      return valueList.AsEnumerable();
    }


    //O(N)
    //Recursive
    public IEnumerable<T> GetPostOrder()
    {
      var valueList = new List<T>();     
      PostOrder( Root_, ref valueList );
      return valueList.AsEnumerable();
    }

    //O(N)
    //Non Recursive
    public IEnumerable<T> GetPostOrder_NonRecursive()
    {
      var valueList = new List<T>();      
      var stackA = new Stack<Node<T>>();
      var stackB = new Stack<T>();
      stackA.Push( Root_ );
      Node<T> node;
      
      
      while( stackA.Count > 0 )
      {
        node = stackA.Pop();
        stackB.Push( node.Value );
        
        if( node.Left != null )
        {
          stackA.Push( node.Left );
        }
        
        if( node.Right != null )
        {
          stackA.Push( node.Right );
        }
        
      }
      
      while( stackB.Count > 0 )
      {
        valueList.Add( stackB.Pop() );
      }
     
      return valueList.AsEnumerable();
    }
   
    //O(N)
    //Recursive
    public IEnumerable<T> GetPreOrder()
    {
      var valueList = new List<T>();     
      PreOrder( Root_, ref valueList );
      return valueList.AsEnumerable();
    }
    
    public IEnumerable<T> GetPreOrder_NonRecursive()
    {
      var stack = new Stack<Node<T>>();
      var valueList = new List<T>();    
      
      if( Root_ == null )
      {
        return valueList;
      }
      
      if( Root_.Right == null && Root_.Left == null )
      {
        valueList.Add( Root_.Value );
        return valueList;        
      }
       
      Node<T> node = Root_;
      stack.Push( Root_ );
     
      while ( stack.Count != 0 )
      {
        node = stack.Pop();
        
        valueList.Add( node.Value );
        
        if( node.Right != null )
        {
          stack.Push( node.Right );
        }
        
        if( node.Left != null )
        {
          stack.Push( node.Left );
        }
      }
     
      return valueList.AsEnumerable();
    }
    
    

    //O(N)
    //Non-Recursive
    public IEnumerable<T> GetInLevel()
    {
      var valueQueue = new Queue<Node<T>>();
      var valueList = new List<T>();
      Node<T> node;
      valueQueue.Enqueue( Root_ );

      while( valueQueue.Count > 0 )
      {
        node = valueQueue.Dequeue();
        valueList.Add( node.Value );

        if( node.Left != null )
        {
          valueQueue.Enqueue( node.Left );
        }
        if( node.Right != null )
        {
          valueQueue.Enqueue( node.Right );
        }
      }
      return valueList.AsEnumerable();
    }
    
    //Recursive Function
    void PostOrder( Node<T> node, ref List<T> list )
    {
      if( node != null )
      {
        
        PostOrder( node.Left, ref list );
        PostOrder( node.Right, ref list );
        list.Add( node.Value );
        
      }
    }
    //Recursive Function
    void PreOrder( Node<T> node, ref List<T> list )
    {
      if( node != null )
      {
        list.Add( node.Value );
        PreOrder( node.Left, ref list );
        PreOrder( node.Right, ref list );
      }
    }
    //Recursive Function
    void InOrder( Node<T> node, ref List<T> list )
    {
      if( node != null )
      {
        InOrder( node.Left, ref list );
        list.Add( node.Value );        
        InOrder( node.Right, ref list );
      }
    }
    


    /************************************************************
    Other Functions

    public bool Contains( T value )

    */
    public bool Contains( T value )
    {
      var node = Root_;

      while( node != null )
      {
        if( node.Value.CompareTo( value ) == 0 )
        {
          return true;
        }

        node = ( node.Value.CompareTo( value ) > 0 ) ? node.Left : node.Right;
      }

      return false;
    }

    /************************************************************
    Print Functions

    
    public void PrintByLevel_Simple)

    */
   
    public void PrintByLevel_Simple()
    {
      if( IsEmpty )
      {
        Console.WriteLine("Empty");
        return;
      }
      
      var dict = new IntStrBuildDict();      
      ByLevel( 0, Root_, ref dict );
      
      foreach( var pair in dict )
      {
        Console.WriteLine( pair.Value.ToString() );
      }
    }
    
    void ByLevel( int index, Node<T> node, ref IntStrBuildDict dict )
    {
      System.Text.StringBuilder strBuild = null;
      
      if( node == null )
      {
        return;
      }
      
      if( !dict.TryGetValue( index, out strBuild ) )
      {
        strBuild = new System.Text.StringBuilder( node.Value.ToString() );
        dict.Add( index, strBuild );
      }
      else
      {
        dict[index].Append($", { node.Value.ToString() }");
      }
      
      ByLevel( index + 1, node.Left, ref dict );
      ByLevel( index + 1, node.Right, ref dict );
    }
    
/************************************************************
    Static String Messages
*/

  const string BAD_CALL_EMPTY = "Function call on an empty BST";
  const string BAD_CALL_NOTFOUND = "Function call \"Remove\" on value not in BST.";

/*************************************************************/


    /************************************************************
    Private class

    class Node<N>

    */
    class Node<N>
    {
      public Node( N value ) => Value = value;
      public Node<N> Left { get; set; }
      public Node<N> Right { get; set; }
      public N Value { get; set; }
      public bool IsLeaf { get => Left == null && Right == null; }
    }
  }
}
